## Developer & Contributions

NichoAndianto (Game Developer)
  <br>

## About
Pong 2D [Prototype] is a modern take on the classic arcade game where two players control paddles to bounce a ball back and forth. The project was built to practice fundamental mechanics such as collision detection, scoring systems, and responsive player controls. My contributions include designing the gameplay loop, implementing paddle and ball physics, and creating a smooth two-player experience.

<br>

## Key Features

1. Two-Player Gameplay: Local multiplayer mode with responsive paddle controls.

2. Collision Physics: Ball reacts dynamically to paddle angles and boundaries.

3. Scoring System: Real-time score updates with win condition checks.

<br>

<table>
  <tr>
    <td align="left" width="50%">
      <img width="100%" alt="gif1" src="https://github.com/adxze/adxze/blob/main/0604(2).gif">
    </td>
    <td align="right" width="50%">
      <img width="100%" alt="gif2" src="https://github.com/adxze/adxze/blob/main/0604(3).gif">
    </td>
  </tr>
</table>

## Scene Flow 

```mermaid
flowchart LR
  mm[Main Menu]
  gp[Gameplay]
  es[End Screen]

  mm -- "Click Play" --> gp
  gp -- "Player Misses Ball" --> es
  es -- "Restart" --> gp
  es -- "Main Menu" --> mm

```
## Layer / module Design 

```mermaid
---
config:
  theme: neutral
  look: neo
---
graph TD
    subgraph "Game Initialization"
        Start([Game Start])
        Boot[Boot Layer]
    end
    subgraph "Main Menu"
        MM[Main Menu]
    end
    subgraph "Gameplay Flow"
        GP[Gameplay Scene]
        Paddle[Paddle Controller]
        Ball[Ball Controller]
        Score[Score Manager]
    end
    subgraph "End States"
        ES[End Screen]
    end
    Start --> Boot
    Boot --> MM
    MM -->|Play| GP
    GP --> Paddle
    GP --> Ball
    GP --> Score
    GP -->|Game Over| ES
    ES -->|Restart| GP
    ES -->|Main Menu| MM
    classDef initStyle fill:#e1f5fe,stroke:#01579b,stroke-width:2px
    classDef menuStyle fill:#f3e5f5,stroke:#4a148c,stroke-width:2px
    classDef gameplayStyle fill:#e8f5e8,stroke:#1b5e20,stroke-width:2px
    classDef endStyle fill:#ffebee,stroke:#b71c1c,stroke-width:2px
    class Start,Boot initStyle
    class MM menuStyle
    class GP,Paddle,Ball,Score gameplayStyle
    class ES endStyle


```


## Modules and Features.
| 📂 Name              | 🎬 Scene       | 📋 Responsibility                                                                                            |
| -------------------- | -------------- | ------------------------------------------------------------------------------------------------------------- |
| **MainMenu**         | **Main Menu**  | - Display main menu UI<br/>- Start gameplay when "Play" is pressed<br/>- Exit game when selected              |
| **PaddleController** | **Gameplay**   | - Handle player inputs (Up/Down or W/S)<br/>- Clamp paddle movement within boundaries                         |
| **BallController**   | **Gameplay**   | - Move ball with velocity and direction<br/>- Detect paddle/edge collisions<br/>- Reset ball on scoring event |
| **ScoreManager**     | **Gameplay**   | - Track and display both players’ scores<br/>- Declare winner when score limit reached                        |
| **GameOver**         | **End Screen** | - Show winner information<br/>- Restart or return to main menu                                                |


<br>


## Game Flow Chart


```mermaid
---
config:
  theme: redux
  look: neo
---
flowchart TD
  start([Game Start])
  start --> input{Player Input}
  input -->|"Move Paddle"| paddle[Move Paddle]
  input -->|"Ball Movement"| ball[Update Ball Position]
  ball --> collide{Collision?}
  collide -->|Paddle| reflect[Reflect Ball]
  collide -->|Wall| bounce[Change Y Direction]
  collide -->|Miss| score[Update Score]
  reflect --> loop[Continue Gameplay]
  bounce --> loop
  score --> checkWin{Win Condition Met?}
  checkWin -->|No| resetBall[Reset Ball and Continue]
  checkWin -->|Yes| end[Game Over Screen]
  resetBall --> loop
  loop --> input

```


<br>

## Event Signal Diagram


```mermaid
classDiagram
    class PaddleController {
        +OnMoveUp()
        +OnMoveDown()
        +OnClampBoundary()
    }

    class BallController {
        +OnCollideWithPaddle()
        +OnCollideWithWall()
        +OnResetPosition()
    }

    class ScoreManager {
        +OnPointScored(playerID: int)
        +OnCheckWin()
    }

    class GameManager {
        +OnGameStart()
        +OnGameOver()
    }

    PaddleController --> BallController : collision triggers
    BallController --> ScoreManager : sends point scored
    ScoreManager --> GameManager : triggers win condition



```






![Platform Demo](https://raw.githubusercontent.com/adxze/adxze/main/PlatfromSlide.png)
