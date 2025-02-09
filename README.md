# Ocarina_Like_Mechanic
A mechanic that is mostly similar to Legend of Zelda Ocarina of Time's ocarina mechanic - mimics the whole concept of coming near an obstacle and using a musical instrument to progress through the game

Made for unity projects, and is an old iteration of my duduk mech for my game project - Vanakatu, but you can use the logic for other engines of course

How it works: 
1) Player steps into obstacle's collider
2) The 'code' is transferred to the player from the obstacle through a scriptable object (which can be carried through many scenes)
3) The instrument feeds in the char notes that are inputted from the player into the scriptable object
4) The scriptable object checks the validity of the notes by adding them to a string
5) If the string matches the first n characters of the string that was fed from the obstacle, continue until it fully matches its string, else, erase the string
6) Once the string completely matches the obstacle's string, close the musical instrument and move the obstacle out of the way or whatever that progresses the game through an interface's required "DoThing()" method.

That's it!
