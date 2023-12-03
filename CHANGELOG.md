# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/) and this project adheres to Semantic Versioning.

## [Unreleased]
- build: update Newtonnsoft.Json to the latest stable.
- fix: allow for nullable `LowestAsk` and `HighestBid` of the Instruments class.

## [1.1.0] - 2021-01-01
### Fixed
- Update API base and ticker endpoint.
- Account for null values if no trading for 24 hours.

### Added
- Console app with example usage.
- Constructor that takes an `HttpClient`, with updated example of using a Typed Client.

### Deprecated
- Parameterless constructor.

## 1.0.0 - 2018-10-01
### Added
- First release.

[Unreleased]: https://github.com/RobJohnston/Ndax.Api/compare/v1.1.0...HEAD
[1.1.0]: https://github.com/RobJohnston/Ndax.Api/compare/v1.0.0...v1.1.0
