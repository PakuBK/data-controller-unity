# Data manager
Simple Data Manager Tool for Scriptable Objects and more. Easily Extendible.

## How to use

**Player Data**, **Player Data Token** and **Volume Data Token**

---

### How it works

The Player Data is an Scriptable Object which is provided.
You need to create an Instance of this Object by yourself.
The Player Data Token acts as a middle men between your Player Data
and the stored serizalized file.
Everytime you save the player data the data controller creates an
Player Data Token which copy all the Player Data you specify in a 
Token. This Token can than be serizalized. If you want to load 
data back into your Player Data the Data Controller will
read the Token from disc space.

