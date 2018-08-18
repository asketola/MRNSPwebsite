DROP DATABASE Test;
CREATE DATABASE Test;

USE Test;

CREATE TABLE Blog (
    BlogId INT unsigned NOT NULL AUTO_INCREMENT,
    url VARCHAR(150) NOT NULL,
    PRIMARY KEY (BlogId)
);

INSERT INTO Blog ( BlogId, url ) VALUES ( 1, 'test.com' ), ( 2, 'fake.com' );
