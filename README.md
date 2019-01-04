# Qml.Net.TodoApp | [![Build Status](https://travis-ci.com/MaxMommersteeg/Qml.Net.TodoApp.svg?branch=master)](https://travis-ci.com/MaxMommersteeg/Qml.Net.TodoApp)
A simple todo app written using [Qml.Net](https://github.com/qmlnet/qmlnet).

## Running the app
1. Clone this repo
2. Open `TodoApp.sln`
3. Set `TodoApp.FrontEnd` as startup project
4. Hit F5

## TodoApp.FrontEnd
Project that provides a user interface. Containing controllers and views (written in QML).

## TodoApp.Infrastructure
Responsible for maintaining and communicating with the Sqlite database for storage.

## TodoApp.Core
Containing all logic.

# Related projects

- [Qml.Net](https://github.com/qmlnet/qmlnet) - Qt/QML integration/support for .NET
- [Qml.Net.Examples](https://github.com/qmlnet/qmlnet-examples) - Example projects for Qml.Net
- [Qml.Net.Chat](https://github.com/MaxMommersteeg/Qml.Net.Chat) - Simple client-server chat application written with SignalR Core and Qml.Net
