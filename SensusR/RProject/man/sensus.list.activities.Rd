% Generated by roxygen2: do not edit by hand
% Please edit documentation in R/SensusR.R
\name{sensus.list.activities}
\alias{sensus.list.activities}
\title{Lists activities in a given phase and state.}
\usage{
sensus.list.activities(data, phase = "Starting", state = "Active")
}
\arguments{
\item{data}{Data, as returned by \code{\link{sensus.read.json.files}}.}

\item{phase}{Phase of activity (Starting, During, Stopping)}

\item{state}{State of phase (Active, Inactive, Unknown)}
}
\description{
Lists activities in a given phase and state.
}
