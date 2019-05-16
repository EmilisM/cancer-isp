CREATE DATABASE IF NOT EXISTS `cancer_isp_2`;

DROP TABLE IF EXISTS playlist_song;
DROP TABLE IF EXISTS rating;
DROP TABLE IF EXISTS artist_album;
DROP TABLE IF EXISTS artist_song;
DROP TABLE IF EXISTS artist;
DROP TABLE IF EXISTS playlist;
DROP TABLE IF EXISTS song_genre;
DROP TABLE IF EXISTS song;
DROP TABLE IF EXISTS album;
DROP TABLE IF EXISTS user;
DROP TABLE IF EXISTS user_profile;
DROP TABLE IF EXISTS user_role;
DROP TABLE IF EXISTS image;
DROP TABLE IF EXISTS genre;

CREATE TABLE genre (
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255),
  description VARCHAR(255)
); 

CREATE TABLE image (
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255),
  url VARCHAR(255)
); 

CREATE TABLE user_role (
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255)
); 

CREATE TABLE user_profile (
  id INT AUTO_INCREMENT PRIMARY KEY,
  description VARCHAR(255),
  name VARCHAR(255),
  last_name VARCHAR(255),
  birthdate DATE,
  phone_number VARCHAR(255)
);

CREATE TABLE user (
  id INT AUTO_INCREMENT PRIMARY KEY,
  username VARCHAR(255),
  registration_date DATETIME,
  password_hash VARCHAR(255),
  password_salt VARCHAR(255),
  email VARCHAR(255),
  karma_points INT,
  user_role_id INT,
  user_profile_id INT UNIQUE KEY,
  FOREIGN KEY(user_role_id) REFERENCES user_role(id),
  FOREIGN KEY(user_profile_id) REFERENCES user_profile(id)
);

CREATE TABLE album (
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255),
  release_date DATE,
  image_id INT,
  FOREIGN KEY(image_id) REFERENCES image(id)
);

CREATE TABLE song (
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255),
  release_date DATETIME,
  length_in_seconds INT,
  description VARCHAR(255),
  image_id INT,
  album_id INT,
  user_id INT,
  FOREIGN KEY(image_id) REFERENCES image(id),
  FOREIGN KEY(album_id) REFERENCES album(id),
  FOREIGN KEY(user_id) REFERENCES user(id)
); 

CREATE TABLE song_genre (
  song_id INT NOT NULL,
  genre_id INT NOT NULL,
  PRIMARY KEY(song_id, genre_id),
  FOREIGN KEY(song_id) REFERENCES song(id),
  FOREIGN KEY(genre_id) REFERENCES genre(id)
);

CREATE TABLE playlist (
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255),
  description VARCHAR(255),
  state VARCHAR(255),
  user_id INT,
  FOREIGN KEY(user_id) REFERENCES user(id)
);

CREATE TABLE artist (
  id INT AUTO_INCREMENT PRIMARY KEY,
  alias VARCHAR(255),
  full_name VARCHAR(255),
  birthdate DATE,
  description VARCHAR(255),
  origin_date DATE,
  user_id INT NOT NULL,
  FOREIGN KEY(user_id) REFERENCES user(id)
);

CREATE TABLE artist_song (
  song_id INT NOT NULL,
  artist_id INT NOT NULL,
  PRIMARY KEY(song_id, artist_id),
  FOREIGN KEY(song_id) REFERENCES song(id),
  FOREIGN KEY(artist_id) REFERENCES artist(id)
);

CREATE TABLE artist_album (
  artist_id INT NOT NULL,
  album_id INT NOT NULL,
  PRIMARY KEY(artist_id, album_id),
  FOREIGN KEY(artist_id) REFERENCES artist(id),
  FOREIGN KEY(album_id) REFERENCES album(id)
);

CREATE TABLE rating (
  id INT AUTO_INCREMENT PRIMARY KEY,
  points INT,
  creation_date DATE,
  comment VARCHAR(255),
  song_id INT NOT NULL,
  user_id INT NOT NULL,
  FOREIGN KEY(song_id) REFERENCES song(id),
  FOREIGN KEY(user_id) REFERENCES user(id)
);

CREATE TABLE playlist_song (
  playlist_id INT NOT NULL,
  song_id INT NOT NULL,
  PRIMARY KEY(playlist_id, song_id),
  FOREIGN KEY(playlist_id) REFERENCES playlist(id),
  FOREIGN KEY(song_id) REFERENCES song(id)
);