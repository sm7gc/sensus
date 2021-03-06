% Generated by roxygen2: do not edit by hand
% Please edit documentation in R/SensusR.R
\name{plot.TelephonyDatum}
\alias{plot.TelephonyDatum}
\title{Plot telephony data.}
\usage{
\method{plot}{TelephonyDatum}(x, ...)
}
\arguments{
\item{x}{Telephony data.}

\item{...}{Other plotting parameters.}
}
\description{
Plot telephony data.
}
\examples{
data.path = system.file("extdata", "example-data", package="SensusR")
data = sensus.read.json.files(data.path)
plot(data$TelephonyDatum)
}
