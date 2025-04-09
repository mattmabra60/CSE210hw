# Magic: The Gathering Card Manager

## Overview
This project is a console-based application for managing a collection of Magic: The Gathering cards and decks. 
It allows users to create, view, and manage cards and decks, as well as save and load collections from files.

## Features
- Card Management:
    - View all cards in the collection.
    - Filter cards by color.
    - Create new cards of various types (Creature, Spell, Planeswalker, Land).

- Deck Management:
    - View all decks.
    - View detailed information about a specific deck, including color distribution and average mana cost.
    - Create new decks.
    - Add cards to decks.

- File Operations:
    - Save the entire collection (cards and decks) to a file.
    - Load a collection from a file.

## Card Types
The application supports the following card types:
1. Creature Cards: Cards with power, toughness, and abilities.
2. Spell Cards: Cards with effects (e.g., Instant, Sorcery).
3. Planeswalker Cards: Cards with loyalty and abilities.
4. Land Cards: Cards that provide mana or other abilities.

## How to Use
1. Run the application.
2. Use the menu to navigate through the options:
     - View cards or decks.
     - Create new cards or decks.
     - Add cards to decks.
     - Save or load your collection.
3. Follow the prompts to input details for cards or decks.

The goal for these sections will be to eventually replace them with a file.write system and have all of this information being called
from and written to a series of files
[## Example Cards
- Fireball (Spell): Deals X damage divided among targets.
- Llanowar Elves (Creature): Adds green mana to your pool.
- Wrath of God (Spell): Destroys all creatures.
- Serra the Benevolent (Planeswalker): Creates flying Angel tokens.
- Wasteland (Land): Destroys nonbasic lands.

## Example Decks
- Control Deck: Focuses on controlling the game with cards like Wrath of God and Serra the Benevolent.
- Aggro Deck: Focuses on fast damage with cards like Fireball and Llanowar Elves.]

## File Operations
- Save Collection: Save your cards and decks to a file for later use.
- Load Collection: Load a previously saved collection to continue managing your cards and decks.

## Future Enhancements
- Add support for importing/exporting collections in popular formats like to text files readable by the TCGplayer cardbank and Moxfeild.
- Implement advanced search and filtering options.
- Add graphical user interface (GUI) for improved usability I do not know how to do this yet and I would like to maybe use some python
too make this if I can I just am not sure yet.

## Author
This project was created as part of a final project for CSE210.
Credit: Matthew Abraham
Created: 04.04.2025

Enjoy managing your Magic: The Gathering collection!