use LouvreDatabase

/* Inserting data into the Artists table: */

INSERT INTO Artists (FullName, Birth_Date, Death_Date, Style, Genres)
VALUES 
('Leonardo da Vinci', '1452-04-15', '1519-05-02', 'Renaissance', 'Painting, Sculpture, Architecture, Engineering'),
('Vincent van Gogh', '1853-03-30', '1890-07-29', 'Post-Impressionism', 'Painting'),
('Pablo Picasso', '1881-10-25', '1973-04-08', 'Cubism', 'Painting, Sculpture, Printmaking'),
('Claude Monet', '1840-11-14', '1926-12-05', 'Impressionism', 'Painting'),
('Michelangelo Buonarroti', '1475-03-06', '1564-02-18', 'High Renaissance', 'Sculpture, Painting, Architecture, Poetry'),
('Rembrandt van Rijn', '1606-07-15', '1669-10-04', 'Dutch Golden Age, Baroque', 'Painting, Printmaking'),
('Salvador Dali', '1904-05-11', '1989-01-23', 'Surrealism', 'Painting, Drawing, Photography, Sculpture, Film'),
('Edvard Munch', '1863-12-12', '1944-01-23', 'Expressionism', 'Painting, Printmaking'),
('Jackson Pollock', '1912-01-28', '1956-08-11', 'Abstract Expressionism', 'Painting'),
('Frida Kahlo', '1907-07-06', '1954-07-13', 'Surrealism, Magic Realism', 'Painting');
select * from  Artists
/*Inserting data into the Categories table:*/
INSERT INTO Categories (CategoryName, Description, Keywords, Notes)
VALUES
('Sculptures', 'A form of visual art that operates in three dimensions.', 'marble, bronze, clay', 'This category includes sculptures from different periods and styles.'),
('Photography', 'A process of capturing an image using light and cameras.', 'black and white, color, digital', 'This category includes photographs from different periods and styles.'),
('Drawings', 'A form of visual art in which a person uses various drawing instruments to mark paper or another two-dimensional medium.', 'pencil, charcoal, ink', 'This category includes drawings from different periods and styles.'),
('Prints', 'A form of art that involves creating an image on a surface and then transferring that image onto paper or another material.', 'etching, lithography, screen printing', 'This category includes prints from different periods and styles.'),
('Sculptural Objects', 'Three-dimensional objects created through a variety of techniques and mediums.', 'metal, wood, stone', 'This category includes sculptural objects from different periods and styles.'),
('Textiles', 'A type of material made from natural or synthetic fibers.', 'cotton, wool, silk', 'This category includes textile works from different periods and styles.'),
('Furniture', 'Objects that can be moved and used to support various human activities.', 'chairs, tables, desks', 'This category includes furniture from different periods and styles.'),
('Decorative Art', 'Artwork created to enhance or complement the decor of a space.', 'ceramics, glass, metalwork', 'This category includes decorative art objects from different periods and styles.'),
('Jewelry', 'Objects worn for personal adornment.', 'gold, silver, diamonds', 'This category includes jewelry from different periods and styles.'),
('Coins and Medals', 'Metal objects used for monetary purposes or commemoration.', 'gold, silver, bronze', 'This category includes coins and medals from different periods and styles.'),
('Weapons and Armor', 'Objects designed for use in combat or defense.', 'swords, shields, helmets', 'This category includes weapons and armor from different periods and styles.'),
('Musical Instruments', 'Objects used to produce musical sounds.', 'guitar, piano, violin', 'This category includes musical instruments from different periods and styles.'),
('Scientific Instruments', 'Objects used to measure, observe, or study various phenomena.', 'microscopes, telescopes, compasses', 'This category includes scientific instruments from different periods and styles.'),
('Toys and Games', 'Objects used for amusement or play.', 'dolls, board games, puzzles', 'This category includes toys and games from different periods and styles.'),
('Fossils', 'Remains or traces of ancient organisms preserved in rock.', 'dinosaurs, trilobites, ammonites', 'This category includes fossils from different periods and species.');
/*Inserting data into the CollectionParts table:*/

/*Inserting data into the Collections table:*/
INSERT INTO Collections (department, period_start, period_end)
VALUES 
('Antiquities', '0800-01-01', '0900-12-31'),
('Medieval Art', '0500-01-01', '1500-12-31'),
('Renaissance Art', '1400-01-01', '1600-12-31'),
('Baroque Art', '1600-01-01', '1750-12-31'),
('Neoclassical Art', '1750-01-01', '1850-12-31'),
('Romanticism Art', '1800-01-01', '1850-12-31'),
('Realism Art', '1840-01-01', '1880-12-31'),
('Impressionism Art', '1860-01-01', '1900-12-31'),
('Modern Art', '1900-01-01', '1960-12-31'),
('Contemporary Art', '1960-01-01', '9999-12-31'),
('East Asian Art', '0500-01-01', '9999-12-31'),
('Islamic Art', '0600-01-01', '9999-12-31'),
('African Art', '1000-01-01', '9999-12-31'),
('Oceanic Art', '1000-01-01', '9999-12-31'),
('Native American Art', '1000-01-01', '9999-12-31');

--SELECT 
--    FormatDate(period_start).formatted_date AS formatted_start_date,
--    FormatDate(period_end).formatted_date AS formatted_end_date
--FROM Collections;

select * from  CollectionParts

/*Inserting data into the Directors table:*/

/*Inserting data into the CollectionParts table:*/
-- Adding parts to the Antiquities collection
INSERT INTO CollectionParts (Collection_ID, PartName)
VALUES
    (1003, 'Greek and Roman Sculptures'),
    (1003, 'Egyptian Artifacts'),
    (1003, 'Mesopotamian Artifacts'),
    (1003, 'Mesoamerican Artifacts'),
    (1003, 'East Asian Antiquities');

-- Adding parts to the Medieval Art collection
INSERT INTO CollectionParts (Collection_ID, PartName)
VALUES
    (1004, 'Illuminated Manuscripts'),
    (1004, 'Medieval Sculptures'),
    (1004, 'Stained Glass Windows'),
    (1004, 'Reliquaries');

-- Adding parts to the Renaissance Art collection
INSERT INTO CollectionParts (Collection_ID, PartName)
VALUES
    (1005, 'Italian Renaissance Paintings'),
    (1005, 'Northern Renaissance Paintings'),
    (1005, 'Renaissance Sculptures'),
    (1005, 'Renaissance Drawings');

-- Adding parts to the Baroque Art collection
INSERT INTO CollectionParts (Collection_ID, PartName)
VALUES
    (1006, 'Baroque Paintings'),
    (1006, 'Baroque Sculptures'),
    (1006, 'Baroque Architecture');

-- Adding parts to the Neoclassical Art collection
INSERT INTO CollectionParts (Collection_ID, PartName)
VALUES
    (1007, 'Neoclassical Paintings'),
    (1007, 'Neoclassical Sculptures'),
    (1007, 'Neoclassical Decorative Arts');

-- Adding parts to the Romanticism Art collection
INSERT INTO CollectionParts (Collection_ID, PartName)
VALUES
    (1008, 'Romantic Paintings'),
    (1008, 'Romantic Sculptures'),
    (1008, 'Romantic Prints');

-- Adding parts to the Realism Art collection
INSERT INTO CollectionParts (Collection_ID, PartName)
VALUES
    (1008, 'Realist Paintings'),
    (1008, 'Realist Sculptures'),
    (1008, 'Realist Prints');

-- Adding parts to the Impressionism Art collection
INSERT INTO CollectionParts (Collection_ID, PartName)
VALUES
    (1010, 'Impressionist Paintings'),
    (1010, 'Impressionist Sculptures'),
    (1010, 'Impressionist Prints');

-- Adding parts to the Modern Art collection
INSERT INTO CollectionParts (Collection_ID, PartName)
VALUES
    (1011, 'Modern Paintings'),
    (1011, 'Modern Sculptures'),
    (1011, 'Modern Prints'),
    (1011, 'Modern Photography'),
    (1011, 'Modern Design Objects');

-- Adding parts to the Contemporary Art collection
INSERT INTO CollectionParts (Collection_ID, PartName)
VALUES
    (1012, 'Contemporary Paintings'),
    (1012, 'Contemporary Sculptures'),
    (1012, 'Contemporary Photography'),
    (1012, 'Contemporary Installations');

-- Adding parts to the East Asian Art collection
INSERT INTO CollectionParts (Collection_ID, PartName)
VALUES
    (1013, 'Chinese Paintings'),
    (1013, 'Japanese Paintings'),
    (1013, 'Chinese Ceramics'),
    (1013, 'Japanese Ceramics'),
    (1013, 'Buddhist Artifacts');
-- Adding parts to the Islamic Art collection
INSERT INTO CollectionParts (Collection_ID, PartName)
VALUES
    (1014, 'Islamic Calligraphy'),
    (1014, 'Islamic Miniatures'),
    (1014, 'Islamic Metalwork'),
    (1014, 'Islamic Textiles');
-- Adding parts to the African Art collection


INSERT INTO Directors (FullName)
VALUES ('Jean-Luc Martinez');
INSERT INTO Directors (FullName) VALUES ('Pierre Rosenberg');
INSERT INTO Directors (FullName) VALUES ('Henri Loyrette');
INSERT INTO Directors (FullName) VALUES ('Michel Laclotte');
INSERT INTO Directors (FullName) VALUES ('André Malraux');

/*Inserting data into the LouvreMuseumGalleries table:*/
select * from  Wings_floors

INSERT INTO Wings_floors (Name)
VALUES
('Middle Floor'),
('First Floor'),
('Second Floor')

INSERT INTO LouvreMuseumGalleries (GalleryNumber, Level_ID, WF_ID)
VALUES
('Antiquities Gallery', 1002, 4),
('Medieval Art Gallery', 1003, 2),
('Renaissance Art Gallery', 1004, 2),
('Baroque Art Gallery', 1002, 2),
('Neoclassical Art Gallery', 1005, 4),
('Romanticism Art Gallery', 1004, 2),
('Realism Art Gallery', 1005, 3),
('Impressionism Art Gallery', 1002, 2),
('Modern Art Gallery', 1003, 2);
/*Inserting data into the LouvreMuseumLevels table:*/

INSERT INTO LouvreMuseumLevels (LevelNumber)
VALUES ('Level -1'),
       ('Level 0'),
       ('Level 1'),
	   ('Level 2');

select * from LouvreMuseumLevels
/*Inserting data into the Museams table:*/

INSERT INTO Museams (MuseamName, Location, Dirr_ID)
VALUES ('Louvre Museum', 'London, France', 2),
	   ('British Museum', 'London, United Kingdom', 3),
       ('Metropolitan Museum of Art', 'New York, USA', 4),
       ('Vatican Museums', 'Vatican City', 5),
       ('National Museum of China', 'Beijing, China', 6);

/*Inserting data into the GalleryObjects table:*/

INSERT INTO Histories 
(Previous_Owner, Acquisition_Date, Acquisition_Mode, Acquisition_Owner, Location, Depositary, Inscription_Signature, Historical_Notes, Additional_Info)
VALUES
('Unknown', 'Unknown', 'Unknown', 'Unknown', 'Unknown', 'Unknown', 'Unknown', 'Unknown', 'Unknown');

INSERT INTO Images (Image_Loc, Photographer, Date_Taken, Additional_Info)
VALUES
('https://api-www.louvre.fr/sites/default/files/2021-01/aphrodite-dite-venus-de-milo.jpg', 'John Smith', '2022-04-01', 'Venus de Milo'),
('https://upload.wikimedia.org/wikipedia/commons/thumb/b/bf/Victoire_de_Samothrace_-_Musee_du_Louvre_-_20190812.jpg/1200px-Victoire_de_Samothrace_-_Musee_du_Louvre_-_20190812.jpg', 'John Smith', '2022-04-01', 'Winged Victory of Samothrace'),
('https://upload.wikimedia.org/wikipedia/commons/thumb/b/b7/Venere_Callipige_Napoli.jpg/1200px-Venere_Callipige_Napoli.jpg', 'John Smith', '2022-04-01', 'Aphrodite Kallipygos'),
('https://upload.wikimedia.org/wikipedia/commons/b/b9/Apollo_del_Belvedere.jpg', 'John Smith', '2022-04-01', 'Apollo Gallery Statue'),
('https://upload.wikimedia.org/wikipedia/commons/4/42/Roman_bronze_copy_of_Myron%E2%80%99s_Discobolos%2C_2nd_century_CE_%28Glyptothek_Munich%29.jpg', 'John Smith', '2022-04-01', 'Discobolus of Myron'),
('https://upload.wikimedia.org/wikipedia/commons/thumb/8/80/Michelangelo%27s_David_-_right_view_2.jpg/1200px-Michelangelo%27s_David_-_right_view_2.jpg', 'John Smith', '2022-04-01', 'David'),
('https://upload.wikimedia.org/wikipedia/commons/1/17/Laocoon_Pio-Clementino_Inv1059-1064-1067.jpg', 'John Smith', '2022-04-01', 'Laocoön and His Sons'),
('https://upload.wikimedia.org/wikipedia/commons/b/be/Narmer_Palette.jpg', 'John Smith', '2022-04-01', 'Narmer Palette');


INSERT INTO Images (Image_Loc, Photographer, Date_Taken, Additional_Info)
VALUES
('https://static01.nyt.com/images/2018/02/09/world/europe/09louvre-1/merlin_133093613_0f248cf8-85a1-4ed4-9a0d-d853d1d2e90a-superJumbo.jpg', null, '2015-11-21', 'Art Looted by Nazis Gets'),
('https://static.timesofisrael.com/www/uploads/2018/01/AP_17353477424143.jpg', null, '2015-11-21', 'Abu Dhabi Louvre'),
('https://storage.kun.uz/source/9/T0_0YorNcTi1Zhcp7Sapi7eRmH4uU0d6.jpg', null, '2015-11-21', 'The Splendors of Uzbekistan’s Oases'),
('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQjhXBDetQweJ9te0u0aDyWDLWYOythV9njjw&usqp=CAU', null, '2015-11-21', 'Natural light for Louvre-Lens Museum'),
('https://i.insider.com/606574b06183e10019819abd?width=700', null, '2015-11-21', 'The Louvre Just Put Its Entire Art Collection');


INSERT INTO Literatures (Title, Author, Publisher, Publication_Date, ISBN, Additional_Info)
VALUES
('Art History: A Very Short Introduction', 'Dana Arnold', 'Oxford University Press', '2004-08-26', '978-0192801814', 'Introduction to art history for beginners');

/*Inserting data into the GalleryObjects table:*/

select * from Categories
select * from Artists
select * from LouvreMuseumGalleries
select * from Collections
select * from Museams
select * from CollectionParts
select * from Images

INSERT INTO GalleryObjects 
(Category_ID, Artist_ID, Gallery_ID, Collection_ID, Museam_ID, Part_ID, title, creation_date, material, width, height, acquisition_mode, acquisition_owner, acquisition_date, location, depositary, inscription_signature, historical_notes, History_ID, Image_ID, Literature_ID)
VALUES
(1003, null, 1004, 1004, 1003, 2009, 'Art Looted by Nazis Gets', '0800-01-01', 'Marble', 203, 98, 'Discovered', 'Unknown', '1820-04-08', 'Sully Wing, Room 338', 'Louvre Museum', NULL, 'The sculpture represents the goddess Aphrodite (known as Venus in Roman mythology) and is believed to have been created during the Hellenistic period.', null, 1010, NULL),
(1003, null, 1004, 1004, 1003, 2009, 'Abu Dhabi Louvre', '0800-01-01', 'Marble', 244, 220, 'Discovery', 'Charles Champoiseau', '1863-04-15', 'Daru Staircase, Louvre Pyramid', 'Louvre Museum', NULL, 'The sculpture is a depiction of Nike, the Greek goddess of victory, and is believed to have been created during the Hellenistic period.', null, 1011, NULL),
(1003, null, 1004, 1004, 1003, 2009, 'The Splendors of Uzbekistan’s Oases', '0800-01-01', 'Marble', 41, 34, 'Purchase', 'Louvre Museum', '1921-01-31', 'Sully Wing, Room 314', 'Louvre Museum', NULL, 'The sculpture represents the goddess Aphrodite and is notable for its emphasis on her buttocks, which has earned it the nickname "Venus Callipyge" (Venus of the Beautiful Buttocks).', null, 1012, NULL),
(1003, null, 1004, 1004, 1003, 2009, 'Natural light for Louvre-Lens Museum', '0800-01-01', 'Marble', 187, 60, 'Purchase', 'Louvre Museum', '1807-02-06', 'Richelieu Wing, Apollo Gallery', 'Louvre Museum', NULL, 'The statue is believed to represent the god Apollo and is notable for its intricate carving and the delicate drapery that falls across the figure.', null, 1013, NULL),
(1003, null, 1004, 1004, 1003, 2009, 'The Louvre Just Put Its Entire Art Collection', '0800-01-01', 'Marble', 155, 148, 'Purchase', 'Pope Clement XIV', '1781-03-10', 'Sully Wing, Room 310', 'Louvre Museum', NULL, 'The sculpture represents a discus thrower and is notable for its lifelike depiction of the athlete in motion.', null, 1014, NULL);


INSERT INTO GalleryObjects (Category_ID, Artist_ID, Gallery_ID, Collection_ID, Museam_ID, Part_ID, title, creation_date, material, width, height, acquisition_mode, acquisition_owner, acquisition_date, location, depositary, inscription_signature, historical_notes, History_ID, Image_ID, Literature_ID)
VALUES
(1002, 1002, 1003, 1003, 1003, 2003, 'Venus de Milo', '0800-01-01', 'Marble', 203, 98, 'Discovered', 'Unknown', '1820-04-08', 'Sully Wing, Room 338', 'Louvre Museum', NULL, 'The sculpture represents the goddess Aphrodite (known as Venus in Roman mythology) and is believed to have been created during the Hellenistic period.', null, 1002, NULL),

/*Inserting data into the OnDisplayNow table:*/

INSERT INTO OnDisplayNow (DisNow_ID, isDisplayNow, Object_ID)
VALUES (1, 1, 1);

/*Inserting data into the Raiting table:*/

INSERT INTO Raiting (Raiting_ID, Object_ID, User_ID, Rating)
VALUES (1, 1, 1, 5);

/*Inserting data into the Theme_Album table:*/

INSERT INTO Theme_Album (Album_ID, Name, Description, Object_ID)
VALUES (1, 'Masterpieces of the Louvre Museum', 'This album features some of the most famous and iconic works of art in the Louvre Museum collection.', 1);