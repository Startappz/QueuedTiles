Queued Tiles
=======
An open-source project demonstrates how to add queued tiles to your windows 8 and windows phone project.

![Example](/tile_preview.gif)

Queued Tiles
---
A queue of tiles that is changed automatically.

Answered Questions
----

The project answers the following questions:

* What is tile, queued tiles in Windows 8 and Windows Phone?
* How to implement tiles in Windows 8 and Windows Phone?
* How to implement queued tiles in Windows 8 and Windows Phone that is changed every period of time?
* How to implement tiles in a Universal App?
* How to clear (reset) tile and back to the app icon?
* How to scale tile image?

Run
---
```
TilesManager.ShowQueuedTiles();
```

Clear (Reset)
---
```
TileUpdateManager.CreateTileUpdaterForApplication().Clear();
```

Operating system requirements
---

- Windows 8.1
- Windows Phone 8.1

Developed By
------------

Bilal Sammour


License
-------

    Copyright 2015 Bilal Sammour
    
    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at
    
    http://www.apache.org/licenses/LICENSE-2.0
    
    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.

