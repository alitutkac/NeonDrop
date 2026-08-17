# 🌌 NeonDrop — 2D Cyber-Neon Endless Arcade Game

[![Unity Version](https://img.shields.io/badge/Unity-6000.4.2f1-000000.svg?style=for-the-badge&logo=unity&logoColor=white)](https://unity.com/)
[![Platform](https://img.shields.io/badge/Platform-Android%20%7C%20Mobile-3DDC84.svg?style=for-the-badge&logo=android&logoColor=white)](https://www.android.com/)
[![Language](https://img.shields.io/badge/Language-C%23-239120.svg?style=for-the-badge&logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)

**NeonDrop** is a fast-paced, reflex-driven 2D mobile arcade game built with Unity 6. Featuring dynamic procedural difficulty, responsive touch mechanics, and a sleek retro-futuristic neon aesthetic powered by the Universal Render Pipeline (URP).

---

## 🎮 Overview & Core Gameplay

The primary objective is simple yet demanding: navigate a vibrant glowing orb through an increasingly rapid cascade of neon obstacles. The game tests reaction time and precision with infinite progression and persistent high-score tracking.

<p align="center">
  <img src=".github/images/gameplay.gif" width="280"/>
</p>

### Key Highlights
* **Dynamic Difficulty Curve:** Obstacle speed scales progressively over time, demanding tighter precision and faster reflexes.
* **Neon Aesthetic & Post-Processing:** Universal Render Pipeline (URP 2D) combined with custom Bloom and HDR materials for real-time emission effects.
* **Mobile-Optimized Touch Controls:** Smooth, zero-latency screen tap/drag input handling tailored for portrait mode.
* **Persistent High Score:** Local storage management utilizing `PlayerPrefs` for real-time best-score comparison.
* **Modular Game Architecture:** Integrated State Management covering Main Menu navigation, In-Game Pause/Resume states, and Game Over logic.
* **Production-Ready Build:** Compiled using Android NDK with IL2CPP backend, targeting ARM64 and ARMv7 architectures.

---

## 📸 Screenshots

<p align="center">
  <img src=".github/images/main-menu.jpeg" width="200"/>
  <img src=".github/images/game.jpg" width="200"/>
  <img src=".github/images/pause-menu.jpg" width="200"/>
  <img src=".github/images/game-over.jpg" width="200"/>
</p>

---

## 🛠️ Tech Stack & Architecture

* **Engine:** Unity 6 (6000.4.2f1)
* **Language:** C# (.NET Framework)
* **Rendering:** Universal Render Pipeline (URP 2D) with Bloom & Post-Processing
* **UI Framework:** TextMeshPro (SDF Materials, Scalable Canvas 1080x1920)
* **Scripting Backend:** IL2CPP (Android ARMv7 / ARM64)
* **Build & Tooling:** Gradle 8.x, Android SDK/NDK, OpenJDK
* **Version Control:** Git & GitHub

---

## 🚀 Getting Started

### Prerequisites
* Unity Hub with Unity 6 (6000.4.2f1) installed.
* Android Build Support module (including Android SDK & NDK Tools and OpenJDK).

### Running in Unity Editor
1. Clone the repository: `https://github.com/alitutkac/NeonDrop.git`
2. Open Unity Hub, click **Add project from disk**, and select the `NeonDrop` directory.
3. Open `Assets/Scenes/MainMenu.unity` and hit the **Play** button.

### Installing the Android APK
1. Head over to the Releases section on GitHub.
2. Download `NeonDrop.apk` directly onto your Android device.
3. Enable installation from unknown sources and launch the game.

---

## 👨‍💻 Developer

**Ali TUTKAÇ**  
*Computer Engineering Student — Karadeniz Technical University*  
* **GitHub:** [@alitutkac](https://github.com/alitutkac)
