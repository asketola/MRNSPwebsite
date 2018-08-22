DROP DATABASE Test;
CREATE DATABASE Test;

USE Test;

CREATE TABLE Members (
    firstName VARCHAR(20) NOT NULL,
    lastName VARCHAR(20) NOT NULL,
    emailAddress VARCHAR(40) NOT NULL,
    password VARCHAR(120) NOT NULL,
    role ENUM('admin','grunt','guest'),

    PRIMARY KEY (firstName, lastName)
);

INSERT INTO Members ( firstName, lastName, emailAddress, password, role )
    VALUES ( 'Dorian', 'Issa', 'issadorian@gmail.com', 'defaultdefault', 'grunt');
