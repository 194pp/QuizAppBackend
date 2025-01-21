# Technical Task - Quiz Application

---

## Table of Contents

1. [Introduction](#introduction)
2. [Features](#features)
3. [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
4. [Usage](#usage)

---

## Introduction

This is a web-based quiz application built using **ASP.NET Core**, designed to provide an engaging and interactive quiz experience. Users can answer quiz questions, calculate their scores, and view high scores.

## Features

- Built with **ASP.NET Core** for cross-platform support.
- Uses **Entity Framework Core** for database management.
- Supports **in-memory database** for testing and development.
- Interactive quiz with scoring functionality.
- Highscore leaderboard.

## Getting Started

Follow the steps below to set up and run the application locally.

### Prerequisites

Ensure you have the following installed:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- Git (optional, for version control)

### Installation

1. **Clone the repository**:

   ```bash
   git clone https://github.com/194pp/QuizAppBackend.git
   cd QuizAppBackend
   ```

2. **Restore dependencies**:

   ```bash
   dotnet restore
   ```

3. **Run the application**:

   ```bash
   dotnet run
   ```

4. **Access the application**:
   Open your browser and navigate to `http://localhost:5158` (default URL).

## Usage

This application allows users to:

- Fetch quiz questions and answer options.
- Submit their answers to calculate their score.
- View the high scores of other participants.

## API Endpoints

Here are the API endpoints available:

### Quiz Endpoints

- **GET** `/api/quiz`
  - Retrieves the quiz questions along with answer options.

- **POST** `/api/quiz`
  - Submits user answers to calculate the score.
  - **Request Body Example:**
    ```json
    {
      "email": string,  
      "answers": {
        id: Guid,
        selectableAnswers?: number[],
        textAnswer?: string,
      }[]
    }
    ```
  - **Response Example:**
    ```json
    {
      "message": "Answers submitted successfully."
    }
    ```

### Highscore Endpoint

- **GET** `/api/highscore`
  - Retrieves the highscores of users who have taken the quiz.
  - **Response Example:**
    ```json
    [
      { "email": "alice@gmail.com", "score": 10 },
      { "email": "bob@gmail.com", "score": 8 }
    ]
    ```

