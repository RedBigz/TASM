# Totally Accurate Server Mod
*Just so you know, this project is extremely WIP! If you have bugs, open an [issue](https://github.com/RedBigz/TASM/issues) or a [PR](https://github.com/RedBigz/TASM/pulls).*

This mod adds plugin support to Totally Accurate Battlegrounds' server.

## Installation Instructions
### 1. Clone the Repo
#### Using Git
Open your Terminal and navigate to a folder you want your git repo stored. Then, run `git clone https://github.com/RedBigz/TASM` to clone the directory.
Then, navigate to the repo by running `cd TASM`.
> [!TIP]  
> If you want to update this repository locally so you can build newer versions, just run `git pull` in the repo's directory.

### 2. Referencing Game Assemblies
Since I cannot legally distribute TABG's source code, you will have to reference your game assemblies. I made it fairly easy to do this by running:

*(You will need to substitute the path to TDS [TABG Dedicated Server] if you installed it in a different location)**
#### powershell
```powershell
cp -Recurse "C:\Program Files (x86)\Steam\steamapps\common\TotallyAccurateBattlegroundsDedicatedServer\TABG_Data\Managed\" GameLibs
```

### 3. Building
Just plop the Solution into the IDE of your choice and press **Build Solution**.

### 4. Installing
Install [BepInEx](https://github.com/BepInEx/BepInEx) into TDS and copy `TASM.dll` into `BepInEx/plugins`, and `TASM.Common.dll` into `BepInEx/core`.

*Enjoy!*