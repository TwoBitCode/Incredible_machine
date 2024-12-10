# **🎮 The Incredible Machine - Unity Game Project**  

---

## **📖 Overview**  
Welcome to **The Incredible Machine**, a physics-based puzzle game built in Unity. Solve intricate puzzles using objects like balls, ropes, magnets, and mechanical levers. Each level challenges your creativity and problem-solving skills.  

---

## **⚙️ Gameplay Mechanics**  

### **🔧 1. Draggable Objects**  
- Drag interactive objects like balls and levers using the mouse.  
- Prevents dragging beyond predefined boundaries.  

**🖥️ Sample Code:**  
```csharp
private void OnMouseDrag()
{
    Vector3 mousePosition = GetMouseWorldPosition() + offset;
    float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);
    transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
}
```

---

### **✂️ 2. Rope Cutting**  
- Simulate cutting a rope using collisions with a knife.  
- When the rope is cut, objects like balls or stones are released.  

**🖥️ Sample Code:**  
```csharp
private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Knife"))
    {
        Destroy(joint);  // Release the object
        Destroy(gameObject);  // Optionally remove the rope
    }
}
```

---

### **🏌️ 3. Throwing Mechanism**  
- Use torque-based rotation to throw balls or activate levers.  
- Press **`Space`** to trigger the mechanism.  

**🖥️ Sample Code:**  
```csharp
private void Update()
{
    if (Input.GetKeyDown(KeyCode.Space) && !isActivated)
    {
        arm.AddTorque(torqueForce, ForceMode2D.Impulse);
    }
}
```

---

### **🌀 4. Spring Launcher**  
- Launch a ball by applying an impulse force when pressing **`Space`**.  
- The longer you press, the more powerful the launch becomes.  

**🖥️ Sample Code:**  
```csharp
private void ActivateSpring()
{
    ball.AddForce(Vector2.right * springForce, ForceMode2D.Impulse);
}
```

---

### **🧲 5. Magnetic Fields**  
- Activate magnetic fields that attract metallic objects when triggered.  
- Triggered through switches and collision events.  

**🖥️ Sample Code:**  
```csharp
private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("TriggerDomino"))
    {
        magnetEffector.enabled = true;
        Debug.Log("Magnet Activated!");
    }
}
```

---

### **🚪 6. Environmental Triggers**  
- Use dynamic triggers to activate gates, platforms, and other in-game objects.  
- Trigger objects based on collisions and game events.  

**🖥️ Sample Code:**  
```csharp
private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Ball"))
    {
        Debug.Log("Switch Activated!");
        gate.SetActive(false);  // Disable the gate
    }
}
```

---

---

## **🛠️ Installation Guide**  

1. **Clone the Repository:**  
   ```bash
   git clone https://github.com/TwoBitCode/IncredibleMachine.git
   ```

2. **Open the Project:**  
   - Use **Unity 2021.x or later**.  
   - Open the cloned project in Unity.  

3. **Tag Setup:**  
   - Add required tags in Unity:  
     - `Ball`  
     - `Knife`  
     - `MagnetBall`  
     - `Domino`  
     - `TriggerDomino`  

---

## **🎮 How to Play**  

- **🖱️ Mouse Clicks:** Drag objects like balls, levers, and platforms.  
- **🔴 `Space` Key:** Activate throwing mechanisms, spring launchers, and more.  
- **✅ Complete Levels:** Solve puzzles by creating chain reactions, pressing switches, and using physics-based interactions.  

---

---

## **🌐 Play the Game on Itch.io!**  
[🎮 **Play The Incredible Machine on Itch.io**](https://twobitcode.itch.io/incredible-machine)  

---

**Have fun solving incredible physics-based puzzles!** 🚀🎯
