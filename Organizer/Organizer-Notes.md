#General

The goal of the Dojo is two-fold:
* provide a basic introduction to [Canopy][canopy], a F# web UI testing library,
* write a game loop to automatically play the game of [2048][2048], against the actual game page. 

The Dojo itself doesn't require much in terms of introduction. Play a game of 2048 live to demonstrate the rules (4 actions are possible, press up/down/left/right, adjacent tiles of same value get collapsed into one, the goal is to get a 2048 tile) - and then direct people to the file `Program.fs`, which is a console app containing a set of Tasks leading to a basic working bot. For people who prefer to work with F# interactive, you can direct them to `Script.fsx`.

The dojo progresses from:
* using basic Canopy commands, to start the browser and communicate with the 2048 page (tasks 1 to 4),
* write a recursive loop to play random commands at each turn (task 5),
* use the Interactions module, which contains a couple of pre-written functions, to terminate the loop if the game has been won or lost (task 6),
* start writing a smarter bot and experimenting with strategies (tasks 7 and 8).

##Running on OSX with Xamarin

1. Download [Xamarin Studio]. The Starter edition should work fine for this Dojo. 
2. Open terminal and type the following commands:

```
export MONO_IOMAP=all
mkdir $HOME/.config/canopy
open /Applications/Xamarin\ Studio.app/
```

##Potential pitfalls:
* Canopy works with multiple browsers. By default, if firefox is installed, it should "just work". Other browsers, like Chrome or IE, will probably require the installation of a browser driver (chromedriver.exe or IEDriverServer.exe) in C:\. If the driver is not installed, a message box will show up, which should indicate where Canopy is looking for the driver, and therefore where the corresponding .exe file should be downloaded.
* The Dojo works on Mono (OSX and Linux), with some potential caveats due to paths in mono. [MONO_IOMAP][mono-iomap] seemed to do the trick. 
```
#install fsharp, nuget   
nuget install   
export MONO_IOMAP=all # tells mono to fix some backslash in paths issues   
fsharpc *.fs $(for i in **/*dll; do echo -r $i; done) # compile, passing dll's as resources   
MONO_PATH=$(for i in **/*dll; do echo -n $(dirname $i):; done) mono Program.exe # run, adding dlls' directories in  path   
```

[canopy]: http://lefthandedgoat.github.io/canopy/ "Canopy"
[2048]: http://gabrielecirulli.github.io/2048/ "2048"
[mono-iomap]: http://mono-project.com/MONO_IOMAP "MONO IOMAP"
[Xamarin Studio]: http://xamarin.com/download
