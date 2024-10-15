CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture'
  ) default charset utf8mb4 COMMENT '';

CREATE TABLE
  sandwiches (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    meat VARCHAR(255) COMMENT 'the type of meat on a sandwich. Not required',
    bread VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL,
    price DECIMAL(5, 2) NOT NULL,
    cheese VARCHAR(255),
    -- Under the hood this is a TINYINT(1) (0 or 1)
    isToasted BOOLEAN DEFAULT false,
    condiment VARCHAR(255),
    calories SMALLINT UNSIGNED NOT NULL
  );

ALTER TABLE sandwiches MODIFY calories SMALLINT UNSIGNED NOT NULL;

DROP TABLE sandwiches;

INSERT INTO
  sandwiches (
    meat,
    bread,
    name,
    price,
    cheese,
    isToasted,
    condiment,
    calories
  )
VALUES
  (
    null,
    "white",
    "Cheese Slam Sammy",
    10,
    "american",
    true,
    "american cheese",
    1776
  );

SELECT
  *
FROM
  sandwiches;

DELETE FROM sandwiches
WHERE
  id = 6
LIMIT
  1;