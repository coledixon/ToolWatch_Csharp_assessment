# ToolWatch_Csharp_assessment
 C# based coding practical for ToolWatch

-- simple logging console application.

- program identifies if the base environment and defaults the log type based on DEBUG / RELEASE state(s)
- 3 different logging classes are defined with similar functionality derived from an interface (ILogger)
	- DEBUG
	- INFO (base logging)
	- ERROR
- these 3 logger types are controlled based on the state of the program as it runs / encounters an error
- logs are stored in the hidden AppData folder for the roaming user account
- log files are named of the UTC ticks drawn from the computer datetime components
