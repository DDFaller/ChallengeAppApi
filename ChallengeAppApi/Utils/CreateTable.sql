CREATE TABLE Challenges
(
    Id INT IDENTITY(0, 1) PRIMARY KEY,
    Name VARCHAR(40) NOT NULL,
    DifficultyLevel INT,
    Description VARCHAR(200),
    Duration INT,
    StartedAt DATETIME,
    GithubLink VARCHAR(80)
);