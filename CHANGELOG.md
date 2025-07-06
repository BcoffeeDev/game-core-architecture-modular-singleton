# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),  
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [1.2.0] - 2025-07-06

### Changed
- Renamed namespace to `BCF.Core.ModularSingleton` for long-term maintainability and to prevent naming conflicts.

---

## [1.1.0] - 2025-06-15

### Added
- Introduced generic container system `BaseContainer<T>` to support multiple modular containers.
- Each container now supports its own initialization lifecycle and callbacks.
- Added example usage with `DemoContainer` and sample modules to demonstrate modular setup.

### Changed
- `ModuleContainer` is now removed in favor of extensible container definitions.
- Introduced `DemoContainer` as a working example built on `BaseContainer<T>`.
- Module initialization tracking and event registration are now type-safe and per-container.

---

## [1.0.0] - 2025-06-11

### Added
- Initial release with `ModuleContainer` singleton.
- Support for modular architecture using `BaseModule`.
- Lifecycle management and module access via `GetModule<T>()`.
- Optional cross-scene persistence with `DontDestroyOnLoad`.