% Generated by roxygen2 (4.1.0): do not edit by hand
% Please edit documentation in R/SensusR.R
\name{plot.AltitudeDatum}
\alias{plot.AltitudeDatum}
\title{Plot altitude data.}
\usage{
\method{plot}{AltitudeDatum}(x, pch = ".", type = "l", ...)
}
\arguments{
\item{x}{Altitude data.}

\item{pch}{Plotting character.}

\item{type}{Line type.}

\item{...}{Other plotting parameters.}
}
\description{
Plot altitude data.
}
\examples{
data = read.sensus.json(system.file("extdata", "example.data.txt", package="SensusR"))
plot(data$AltitudeDatum)
}
