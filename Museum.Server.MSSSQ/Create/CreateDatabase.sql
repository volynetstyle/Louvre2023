use LouvreDatabase

CREATE TABLE Artists (
Artist_ID INT IDENTITY(1,1) PRIMARY KEY,
FullName VARCHAR(255),
Birth_Date DATE,
Death_Date DATE,
Style VARCHAR(255),
Genres VARCHAR(255),
CONSTRAINT chk_birth_date CHECK (Birth_Date <= Death_Date)
);

CREATE TABLE Categories (
Category_ID INT IDENTITY(1,1) PRIMARY KEY,
CategoryName VARCHAR(255),
Description TEXT,
Keywords VARCHAR(255),
Notes TEXT,
);

CREATE TABLE CollectionParts (
Part_ID INT IDENTITY(1,1) PRIMARY KEY,
Collection_ID INT,
PartName VARCHAR(255),
CONSTRAINT fk_collection FOREIGN KEY (Collection_ID) REFERENCES Collections(Collection_ID)
);

CREATE TABLE Collections (
Collection_ID INT IDENTITY(1,1) PRIMARY KEY,
department VARCHAR(255),
period_start VARCHAR(255),
period_end VARCHAR(255),
CONSTRAINT chk_period CHECK (period_start <= period_end)
);

CREATE TABLE Directors (
Dirr_ID INT IDENTITY(1,1) PRIMARY KEY,
FullName VARCHAR(255)
);

CREATE TABLE LouvreMuseumGalleries (
Gallery_ID INT IDENTITY(1,1) PRIMARY KEY,
GalleryNumber VARCHAR(255),
Level_ID INT,
WF_ID INT,
CONSTRAINT fk_level FOREIGN KEY (Level_ID) REFERENCES LouvreMuseumLevels(Level_ID),
CONSTRAINT fk_wf FOREIGN KEY (WF_ID) REFERENCES Wings_floors(WF_ID)
);

CREATE TABLE LouvreMuseumLevels (
Level_ID INT IDENTITY(1,1) PRIMARY KEY,
LevelNumber VARCHAR(255)
);

CREATE TABLE Museams (
Museam_ID INT IDENTITY(1,1) PRIMARY KEY,
MuseamName VARCHAR(255),
Location VARCHAR(255),
Dirr_ID INT,
CONSTRAINT fk_director FOREIGN KEY (Dirr_ID) REFERENCES Directors(Dirr_ID)
);

CREATE TABLE GalleryObjects (
Object_ID INT IDENTITY(1,1) PRIMARY KEY,
Category_ID INT,
Artist_ID INT,
Gallery_ID INT,
Collection_ID INT,
Museam_ID INT,
Part_ID INT,
History_ID INT,
Literature_ID INT,

title VARCHAR(255),
creation_date DATE,
material VARCHAR(255),
width INT,
height INT,
acquisition_mode VARCHAR(255),
acquisition_owner VARCHAR(255),
acquisition_date DATE,
location VARCHAR(255),
depositary VARCHAR(255),
inscription_signature VARCHAR(255),
historical_notes TEXT,

CONSTRAINT fk_history FOREIGN KEY (History_ID) REFERENCES Histories(History_ID),
CONSTRAINT fk_literature FOREIGN KEY (Literature_ID) REFERENCES Literatures(Literature_ID),
CONSTRAINT fk_category FOREIGN KEY (Category_ID) REFERENCES Categories(Category_ID),
CONSTRAINT fk_artist FOREIGN KEY (Artist_ID) REFERENCES Artists(Artist_ID),
CONSTRAINT fk_gallery FOREIGN KEY (Gallery_ID) REFERENCES LouvreMuseumGalleries(Gallery_ID),
CONSTRAINT fk_collections FOREIGN KEY (Collection_ID) REFERENCES Collections(Collection_ID),
CONSTRAINT fk_museum FOREIGN KEY (Museam_ID) REFERENCES Museams(Museam_ID),
CONSTRAINT fk_part FOREIGN KEY (Part_ID) REFERENCES CollectionParts(Part_ID)
);

CREATE TABLE OnDisplayNow (
    DisNow_ID INT IDENTITY(1,1) PRIMARY KEY,
    isDisplayNow BIT,
    Object_ID INT,
    CONSTRAINT fk_object1 FOREIGN KEY (Object_ID) REFERENCES GalleryObjects(Object_ID)
);

CREATE TABLE Raiting (
Raiting_ID INT PRIMARY KEY,
Object_ID INT,
User_ID INT,
Rating INT,
CONSTRAINT fk_object FOREIGN KEY (Object_ID) REFERENCES GalleryObjects(Object_ID),
CONSTRAINT fk_user FOREIGN KEY (User_ID) REFERENCES Users(User_ID)
);


CREATE TABLE Theme_Album (
Album_ID INT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(255),
Description TEXT,
Object_ID INT,
CONSTRAINT fk_object2 FOREIGN KEY (Object_ID) REFERENCES GalleryObjects(Object_ID)
);

CREATE TABLE Users (
User_ID INT IDENTITY(1,1) PRIMARY KEY,
UserName VARCHAR(255),
Name VARCHAR(255),
SurName VARCHAR(255),
Email VARCHAR(255)
);

CREATE TABLE Wings_floors (
WF_ID INT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(255),
IsOpen bit,

);


CREATE TABLE Images (
Image_ID INT IDENTITY(1,1) PRIMARY KEY,
Image_Loc VARCHAR(255),
Photographer VARCHAR(255),
Date_Taken DATE,
Additional_Info TEXT,
Object_ID int
CONSTRAINT fk_images FOREIGN KEY (Object_ID) REFERENCES GalleryObjects(Object_ID)
);

CREATE TABLE Literatures (
Literature_ID INT IDENTITY(1,1) PRIMARY KEY,
Title VARCHAR(255),
Author VARCHAR(255),
Publisher VARCHAR(255),
Publication_Date DATE,
ISBN VARCHAR(255),
Additional_Info TEXT
Object_ID int
CONSTRAINT fk_images FOREIGN KEY (Object_ID) REFERENCES GalleryObjects(Object_ID)
);



