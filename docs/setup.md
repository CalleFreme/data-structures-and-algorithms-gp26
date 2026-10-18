# Setup

## Required

- Git
- GitHub account
- .NET 10 SDK
- A C# IDE/editor such as Rider or Visual Studio

Check the SDK:

```bash
dotnet --info
```

You should see a .NET 10 SDK installed.

## Why .NET 10?

The course uses the current Long Term Support release for the standalone C# tooling.

For the core algorithm libraries we intentionally stay conservative:
- target: `.NET Standard 2.1`
- language level: C# 9 where practical

This keeps the core code close to the API/language surface available in current Unity 6 projects.

## First-day commands

From a lab root:

```bash
dotnet restore
dotnet build
dotnet run --project src/DSA.Lab00.App
dotnet test tests/DSA.Lab00.Tests
```

If setup fails, do not lose the entire lab session to installation. Continue the prediction/code-reading tasks and ask for help.
