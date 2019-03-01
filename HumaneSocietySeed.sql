

INSERT INTO Categories VALUES('Dog');
INSERT INTO Categories VALUES('Cat');
INSERT INTO Categories VALUES('Fish');
INSERT INTO Categories VALUES('Rabbit');
INSERT INTO Categories VALUES('Bird');
INSERT INTO Categories VALUES('Ferret');
INSERT INTO Categories VALUES('Elephant');

INSERT INTO DietPlans VALUES('Dog Diet','Dog Food',2);
INSERT INTO DietPlans VALUES('Cat Diet','Cat Food',1);
INSERT INTO DietPlans VALUES('Fish Diet','Fish Food',1);
INSERT INTO DietPlans VALUES('Bird Diet','Bird Food',1);
INSERT INTO DietPlans VALUES('Ferret Diet','Ferret Food',1);
INSERT INTO DietPlans VALUES('Elephant Diet','Succulents',47);
INSERT INTO DietPlans VALUES('Rabbit Diet','Rabbit Food',1);

INSERT INTO Rooms VALUES(100,null);
INSERT INTO Rooms VALUES(101,null);
INSERT INTO Rooms VALUES(102,null);
INSERT INTO Rooms VALUES(103,null);
INSERT INTO Rooms VALUES(104,null);
INSERT INTO Rooms VALUES(105,null);
INSERT INTO Rooms VALUES(106,null);
INSERT INTO Rooms VALUES(107,null);
INSERT INTO Rooms VALUES(108,null);
INSERT INTO Rooms VALUES(109,null);
INSERT INTO Rooms VALUES(110,null);

INSERT INTO Animals VALUES('Fluffy',(SELECT CategoryId FROM Categories WHERE Name = 'Dog'), 6, 4,(SELECT DietPlanId FROM DietPlans WHERE Name = 'Dog Diet'), 'Aggressive', 0, 0, 'Female', 'Available',null);
INSERT INTO Animals VALUES('Sizzle',(SELECT CategoryId FROM Categories WHERE Name = 'Cat'), 20, 2,(SELECT DietPlanId FROM DietPlans WHERE Name = 'Cat Diet'), 'Mild', 1, 0, 'Female', 'Available',null);
INSERT INTO Animals VALUES('Blubba',(SELECT CategoryId FROM Categories WHERE Name = 'Fish'), 1, 1,(SELECT DietPlanId FROM DietPlans WHERE Name = 'Fish Diet'), 'Mild', 0, 1, 'Male', 'Adopted',null);
INSERT INTO Animals VALUES('Cracker',(SELECT CategoryId FROM Categories WHERE Name = 'Bird'), 2, 19,(SELECT DietPlanId FROM DietPlans WHERE Name = 'Bird Diet'), 'Very Aggressive', 0, 1, 'Male', 'Available',null);
INSERT INTO Animals VALUES('Ferris',(SELECT CategoryId FROM Categories WHERE Name = 'Ferret'), 3, 3,(SELECT DietPlanId FROM DietPlans WHERE Name = 'Ferret Diet'), 'Mild', 1, 1, 'Male', 'Available',null);
INSERT INTO Animals VALUES('Elly',(SELECT CategoryId FROM Categories WHERE Name = 'Elephant'), 220, 1,(SELECT DietPlanId FROM DietPlans WHERE Name = 'Elephant Diet'), 'Calm', 1, 1, 'Female', 'Adopted',null);
INSERT INTO Animals VALUES('Stella',(SELECT CategoryId FROM Categories WHERE Name = 'Rabbit'), 4, 2,(SELECT DietPlanId FROM DietPlans WHERE Name = 'Rabbit Diet'), 'Playful', 1, 0, 'Female', 'Adopted',null);


INSERT INTO Shots VALUES('Acepromazine');
INSERT INTO Shots VALUES('Parvovirus');
INSERT INTO Shots VALUES('Pentobarbital');
INSERT INTO Shots VALUES('Parainfluenza');
INSERT INTO Shots VALUES('Leptospirosis');
INSERT INTO Shots VALUES('Coronavirus');
INSERT INTO Shots VALUES('Hepatitis');
INSERT INTO Shots VALUES('Borelia');
INSERT INTO Shots VALUES('Bordetella');
INSERT INTO Shots VALUES('Distemper');
INSERT INTO Shots VALUES('FeLv');
INSERT INTO Shots VALUES('Rabies');
INSERT INTO Shots VALUES('Cylap®');
INSERT INTO Shots VALUES('Polyomavirus');
INSERT INTO Shots VALUES('Tetanus');

UPDATE rooms
SET AnimalId = 1
WHERE RoomId = 1;
UPDATE rooms
SET AnimalId = 2
WHERE RoomId = 2;
UPDATE rooms
SET AnimalId = 3
WHERE RoomId = 3;
UPDATE rooms
SET AnimalId = 4
WHERE RoomId = 4;
UPDATE rooms
SET AnimalId = 5
WHERE RoomId = 5;
UPDATE rooms
SET AnimalId = 6
WHERE RoomId = 6;
UPDATE rooms
SET AnimalId = 7
WHERE RoomId = 7;
UPDATE rooms
SET AnimalId = 8
WHERE RoomId = 8;