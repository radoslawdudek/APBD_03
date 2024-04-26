CREATE TABLE Animal (
    IdAnimal int PRIMARY KEY IDENTITY(1, 1),
    Name nvarchar(200),
    Description nvarchar(200) NULL,
    Category nvarchar(200),
    Area nvarchar(200)
);

INSERT INTO Animal (name, description, category, area)
VALUES ('Bull', 'Big and scary.', 'Mammal', 'Worldwide');

INSERT INTO Animal (name, description, category, area)
VALUES ('Turtle', 'Slow and lives long.', 'Reptile', 'Worldwide');

INSERT INTO Animal (name, description, category, area)
VALUES ('Chicken', NULL, 'Bird', 'Worldwide');