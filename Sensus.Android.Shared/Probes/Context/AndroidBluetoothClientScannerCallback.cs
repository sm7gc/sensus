﻿// Copyright 2014 The Rector & Visitors of the University of Virginia
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using Android.App;
using Android.Bluetooth.LE;
using Android.OS;
using Java.Lang;
using Sensus.Context;
using Android.Bluetooth;
using Sensus.Probes.Context;

namespace Sensus.Android.Probes.Context
{
    /// <summary>
    /// Android BLE client scanner callback. Receives events related to BLE scanning and  
    /// configures a BLE client that requests characteristic values from the server.
    /// </summary>
    public class AndroidBluetoothClientScannerCallback : ScanCallback
    {
        public event EventHandler<BluetoothCharacteristicReadArgs> CharacteristicRead;

        private BluetoothGattService _service;
        private BluetoothGattCharacteristic _characteristic;

        public AndroidBluetoothClientScannerCallback(BluetoothGattService service, BluetoothGattCharacteristic characteristic)
        {
            _service = service;
            _characteristic = characteristic;
        }

        public override void OnScanResult(ScanCallbackType callbackType, ScanResult result)
        {
            ProcessScanResult(result);
        }

        public override void OnBatchScanResults(IList<ScanResult> results)
        {
            foreach (ScanResult result in results)
            {
                ProcessScanResult(result);
            }
        }

        private void ProcessScanResult(ScanResult result)
        {
            if (result == null)
            {
                return;
            }

            try
            {
                // get actual timestamp of encounter. this may be earlier than the current time because we do batch reporting.
                long msSinceEpoch = JavaSystem.CurrentTimeMillis() - SystemClock.ElapsedRealtime() + result.TimestampNanos / 1000000;
                DateTimeOffset encounterTimestamp = new DateTimeOffset(1970, 1, 1, 0, 0, 0, new TimeSpan()).AddMilliseconds(msSinceEpoch);

                // register client callback
                AndroidBluetoothClientGattCallback clientCallback = new AndroidBluetoothClientGattCallback(_service, _characteristic, encounterTimestamp);

                // relay the client read event to any callers scanning for results
                if (CharacteristicRead != null)
                {
                    clientCallback.CharacteristicRead += CharacteristicRead;
                }

                result.Device.ConnectGatt(Application.Context, false, clientCallback);
            }
            catch (System.Exception ex)
            {
                SensusServiceHelper.Get().Logger.Log("Exception while connecting to peripheral:  " + ex, LoggingLevel.Normal, GetType());
            }
        }
    }
}