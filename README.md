# timeWorkTool
track the time spent at work


# timeWorkTool Database
The database is a file json into storage directory, where worktool.exe is it

# timeWorkTool Configuration
The database name is equal to username setted into file worktool.exe.config, look for :  key="user" property and change it!!



```
<!-- worktool.exe.config file-->
<appSettings>
    <add key="user" value="ChangeIt" />
    ...
</appSettings>
```

# timeWorkTool Start Automatically
to start the program automatically when windows starts... on windows10:

type run

and into "run" type

shell:startup

it will open  a folder where you have to put a link to worktool.exe program

