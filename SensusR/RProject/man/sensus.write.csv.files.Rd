% Generated by roxygen2: do not edit by hand
% Please edit documentation in R/SensusR.R
\name{sensus.write.csv.files}
\alias{sensus.write.csv.files}
\title{Write data to CSV files.}
\usage{
sensus.write.csv.files(data, directory, file.name.prefix = "")
}
\arguments{
\item{data}{Data to write, as read using \code{\link{sensus.read.json.files}}.}

\item{directory}{Directory to write CSV files to. Will be created if it does not exist.}

\item{file.name.prefix}{Prefix to add to the generated file names.}
}
\description{
Write data to CSV files.
}
\examples{
data.path = system.file("extdata", "example-data", package="SensusR")
data = sensus.read.json.files(data.path)
# sensus.write.csv.files(data, directory = "/path/to/directory")
}
