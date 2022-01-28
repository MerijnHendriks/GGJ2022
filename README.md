# GGJ2022

Global Game Jam 2022 - Kronii's Homies

## Requirements

- Unity 2020.3 LTS
- Windows 10

## Setup

### Gitub actions

You onky need to do this if you forked the project and want automated testing.

1. Get a unity manual license activation
    1. Run "Acquire activation file" action
    2. Download the produced artifact (zip archive)
2. Get a unity license key
    1. Go to [license.unity3d.com](license.unity3d.com)
    2. Upload the `*.alf` file from the downloaded zip archive
    3. Download license file
3. Add the secret
    1. Open the `*.ulf` file in notepad
    2. Create the secret `UNITY_LICENSE`
    3. Use the content of your license file as value
