DROP DATABASE Test;
CREATE DATABASE Test;

USE Test;

CREATE TABLE Members (
    firstName VARCHAR(20) NOT NULL,
    lastName VARCHAR(20) NOT NULL,
    email VARCHAR(40) ,
    password VARCHAR(20) ,
    role ENUM('admin','grunt','guest') ,

    PRIMARY KEY (firstName, lastName)
);

INSERT INTO Members ( firstName, lastName, email, password, role )
    VALUES ( 'Dorian', 'Issa', 'issadorian@gmail.com', 'defaultdefault', 'grunt');
