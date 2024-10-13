# ChessBoard Console Application

## Description
This is a C# application that lets the user generate a customized chess board in the console.
This application features an interactive menu built with the Spectre.Console library.
The user can navigate through the menu with the up and down arrows and the enter key.

https://spectreconsole.net/ Link to the Spectre.Console website

### Features
* Change the board size - Choose a board size ranging from 1x1 to 8x8.
* Custom tiles - Choose a custom character to represent the tiles.
* Custom chess piece - Choose a custom character to represent the chess piece.
* Piece Placement - Choose where to place your piece on the board.

### Requirements 
* .NET 8

### Get started
If you are using Visual Studio or any other IDE with an integrated repo-cloning function use it with this URL: https://github.com/Marremelad/ChessBoard.git and run the program.

Else, do the following.
* Open the terminal on your computer.
* Navigate to the directory where you keep your repositories.
* Run the following command
```console
git clone https://github.com/Marremelad/ChessBoard.git        
```
* Navigate into the directory that holds the project and run the following command.
```console
dotnet run
```

### Application Demo

#### Main menu
```console
Welcome to the Chess Board Generator!
                                     
> Generate board                     
  Exit                               
```
#### Customization menu
```console
Current Board Size: 8
White Tiles: ◼
Black Tiles: ◻
Piece: ♖
Placement: A1
                     
Customize your board!
                     
> Board Size         
  Custom Tiles       
  Custom Piece       
  Piece Placement    
  Generate Board     
  Exit
```
#### Board generated with default values
```console
◼ ◻ ◼ ◻ ◼ ◻ ◼ ◻
◻ ◼ ◻ ◼ ◻ ◼ ◻ ◼
◼ ◻ ◼ ◻ ◼ ◻ ◼ ◻
◻ ◼ ◻ ◼ ◻ ◼ ◻ ◼
◼ ◻ ◼ ◻ ◼ ◻ ◼ ◻
◻ ◼ ◻ ◼ ◻ ◼ ◻ ◼
◼ ◻ ◼ ◻ ◼ ◻ ◼ ◻
♖ ◼ ◻ ◼ ◻ ◼ ◻ ◼
```
#### Board generated with custom values
```console
O X O X O
X O X O X
O X O X O
X O X O X
O 7 O X O
```







