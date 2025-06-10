# 🧱 Modular Singleton Architecture for Unity

A lightweight and extensible modular architecture framework for Unity projects.  
This package provides a centralized `ModuleContainer` system that manages the lifecycle of self-contained modules derived from `BaseModule`.

## ✨ Features

- 🧩 **Modular Design** – Create independent components by inheriting from `BaseModule`.
- 📦 **Centralized Access** – Retrieve modules via `ModuleContainer.GetModule<T>()`.
- 🔁 **Lifecycle Control** – Built-in initialization flow with callback registration.
- 🌐 **Cross-Scene Support** – Optional `DontDestroyOnLoad` singleton pattern.
- 🔍 **Type-Safe Access** – Generic module resolution without casting.

## 🚀 Getting Started

1. Add the `ModuleContainer` to your scene.
2. Implement your own modules by inheriting from `BaseModule`, and add them to the `modules` list in `ModuleContainer` (either via the Inspector).
3. Access modules in code:
```csharp
var myModule = ModuleContainer.Instance.GetModule<MyCustomModule>();
myModule.DoSomething();
```
4. Optionally, register a callback to wait for module initialization:
```csharp
ModuleContainer.RegisterInitializeCallback(() => {
    Debug.Log("All modules initialized!");
});
```

## 🧪 Use Case

Perfect for:
- Small to mid-sized Unity games or apps
- Prototyping tools or internal systems
- Projects needing clean and maintainable module organization

## 📜 License

MIT License © 2025 [bcoffee](https://github.com/bcoffee0630)