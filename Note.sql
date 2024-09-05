Create database note
use note

CREATE TABLE Notes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Content VARCHAR(MAX) NOT NULL
);
