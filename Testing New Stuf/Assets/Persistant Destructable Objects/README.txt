Start by going to "Assets>Create>Destructable Object Database"
This will be where the state of if the object is destroyed or not is stored
You can name this whatever you want and create as many as you want
It might be a good idea to put different groups of objects into different databases
For examples you might want all of level one's objects to be in the level one database, while level two's are in the level 2 database

Then for your object, you will need a destroyed and undestroyed version of it
Parent both under an Empty GameObject
On the empty gameobject add the "Destructable Object" componenet
Then fill in which database the state will be stored in, the undestroyed version, and the destroyed version

You can then change the destruction state through another script, like SetDestructionOnClick, which is provided in the example.
When you exit playmode the object will to back to how it was when you placed it in the scene, but when you enter playmode it will change to it's proper state

In the example when you click the object it toggles it's destruction state from undestroyed (a tall box), to destroyed (a small box)