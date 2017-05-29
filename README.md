# Background

While making the [Time Fetch API](../projects/timefetch.html), I learnt about how to fetch values from process memory, and used it to fetch the time from the gta_Sa.exe process.  

During that, I saw another memory address which stored the weapon id for the weapon which last hit you. An idea struck me about converting it into a decent app.

# Details

This app is hooked to your game and whenever you lose health, it check the memory for the weapon by which you were hurt. It uses a shadowAPI2 to display the info in-game. Also, there are many features like message color, weapon messages which help you to customize the messages.

# Tutorial

Just press the Link Button and it will attach itself to the game. You can also customize the messages for each weapon.

# Credits

* ### shadowAPI2

It is the only API I could find for GTA SA, but unfortunately its not available anymore. It helps to display messages in game.
