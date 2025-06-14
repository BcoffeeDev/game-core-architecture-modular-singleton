# 🧱 Modular Singleton Architecture for Unity

A lightweight and extensible modular architecture framework for Unity projects.  
This package provides a centralized `BaseContainer<T>` system that manages the lifecycle of self-contained modules derived from `BaseModule`.

## ✨ Features

- 🧩 **Modular Design** – Create independent components by inheriting from `BaseModule`.
- 📦 **Centralized Access** – Retrieve modules via `BaseContainer<T>.Instance.GetModule<M>()`.
- 🔁 **Lifecycle Control** – Built-in initialization flow with callback registration.
- 🌐 **Cross-Scene Support** – Optional `DontDestroyOnLoad` singleton pattern.
- 🔍 **Type-Safe Access** – Generic module resolution without casting.

## 📦 Installation

To install this package in your Unity project using the Unity Package Manager:

1. Open your Unity project.
2. Go to `Window > Package Manager`.
3. Click the `+` button in the top-left corner and select `Add package from Git URL...`
4. Paste the following URL and click `Add`:

```
https://github.com/BcoffeeDev/game-core-architecture-modular-singleton.git
```

Alternatively, you can add it directly to your `manifest.json`:

```json
"dependencies": {
  "com.bcoffee-dev.architecture.modular.singleton": "https://github.com/BcoffeeDev/game-core-architecture-modular-singleton.git"
}
```

## 🚀 Getting Started

1. Create a container by inheriting from `BaseContainer<T>`, and add it to your scene:
```csharp
public class MyGameContainer : BaseContainer<MyGameContainer> { }
```
2. Implement your own modules by inheriting from `BaseModule`, and add them to the `modules` list in your container (either via the Inspector).
3. Access modules in code:
```csharp
var myModule = MyGameContainer.Instance.GetModule<MyCustomModule>();
myModule.DoSomething();
```
4. Optionally, register a callback to wait for module initialization:
```csharp
MyGameContainer.RegisterInitializeCallback(() => {
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