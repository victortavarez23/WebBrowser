# C# Web Browser Implementation Guide

This project is a basic educational exercise in C# using the legacy `WebBrowser` control. It serves as a fundamental introduction to creating a simple desktop web browser interface.

> [!WARNING]  
> **Important Note:** This project relies on the legacy Internet Explorer rendering engine. Consequently, it will have significant limitations when loading and rendering modern websites (such as Google, YouTube, or Facebook). It is intended strictly for learning and educational purposes.

---

## Step-by-Step Implementation Guide

### 1. Setup
1. Open Visual Studio.
2. Create a new project.
3. Choose the **Windows Forms App (.NET Framework)** template.
4. Name your project (e.g., `WebBrowser`) and select a location.

---

### 2. Accessing the Toolbox
If the Toolbox panel is not visible on the left side of your screen:
* Go to the top menu: **View > Toolbox**.
* Alternatively, press the keyboard shortcut `Ctrl + Alt + X`.

---

### 3. Designing the UI
Drag and drop the following components from the Toolbox onto your Form:
* **3 Buttons**: Place these side-by-side at the top for navigation control: "Back", "Forward", and "Go".
* **1 TextBox**: Place this next to the buttons to serve as the URL address bar.
* **1 WebBrowser**: Drag and expand this control to cover the remaining area below the buttons.

---

### 4. Setting Control Properties
Select each component and adjust the following settings in the **Properties** window (typically located in the bottom-right panel):

| Control | Property | Value | Description |
| :--- | :--- | :--- | :--- |
| **button1** | `Text` | `Back` | Go to the previous page |
| **button2** | `Text` | `Forward` | Go to the next page |
| **button3** | `Text` | `Go` | Navigate to the entered URL |
| **textBox1** | `Name` | `textBox1` | Address bar input |
| **webBrowser1** | `Name` | `webBrowser1` | The web viewing panel |

---

### 5. Adding Navigation Functionality
Double-click on each of the buttons to automatically generate their `Click` event handler shell, then insert the corresponding lines of code:

```csharp
// Back Button Event Handler
private void button1_Click(object sender, EventArgs e) 
{
    webBrowser1.GoBack();
}

// Forward Button Event Handler
private void button2_Click(object sender, EventArgs e) 
{
    webBrowser1.GoForward();
}

// Go Button Event Handler
private void button3_Click(object sender, EventArgs e) 
{
    webBrowser1.Navigate(textBox1.Text);
}
```

---

### 6. Enabling the "Enter" Key for Navigation
To allow users to press **Enter** to search or navigate without clicking the "Go" button:
1. Select the `textBox1` control on your Form.
2. In the **Properties** window, click the **lightning bolt icon** (Events).
3. Scroll down to the `KeyDown` event and double-click it to generate the code block.
4. Add the following logic:

```csharp
private void textBox1_KeyDown(object sender, KeyEventArgs e) 
{
    // Check if the pressed key is Enter
    if (e.KeyCode == Keys.Enter) 
    {
        webBrowser1.Navigate(textBox1.Text);
        
        // Prevents the default Windows error "ding" sound
        e.SuppressKeyPress = true; 
    }
}
```

---

### 7. Suppressing Script Errors
Modern web pages contain complex scripts that may cause compatibility popups in the legacy IE engine. You can suppress these script errors by modifying the Form's constructor in `Form1.cs`:

```csharp
public Form1() 
{
    InitializeComponent();
    
    // Suppress script errors and warnings
    webBrowser1.ScriptErrorsSuppressed = true;
}
```

---

### 8. Building the Executable
Once your code is in place, you can build your standalone application:
1. Switch the build configuration dropdown menu at the top of Visual Studio from **Debug** to **Release**.
2. Go to the top menu and select **Build > Build Solution**.
3. Your compiled `.exe` executable file will be located inside your project folder under the path:
   `bin\Release\WebBrowser.exe`
