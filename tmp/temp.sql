DROP DATABASE Test;
CREATE DATABASE Test;

USE Test;

CREATE TABLE Blog (
    BlogId INT unsigned NOT NULL AUTO_INCREMENT,
    url VARCHAR(150) NOT NULL,
    PRIMARY KEY (BlogId)
);

INSERT INTO Blog ( BlogId, url ) VALUES ( 1, 'test.com' ), ( 2, 'fake.com' ), ( 3, 'testing.com' );

CREATE TABLE Members (
    firstName VARCHAR(20) NOT NULL,
    lastName VARCHAR(20) NOT NULL,
    email VARCHAR(40) NOT NULL,
    password VARCHAR(20) NOT NULL,
    role ENUM('admin','grunt','guest') NOT NULL,

    PRIMARY KEY (firstName, lastName)
);

INSERT INTO Members ( firstName, lastName, email, password, role )
    VALUES ( 'Dorian', 'Issa', 'issadorian@gmail.com', 'defaultdefault', 'grunt');
