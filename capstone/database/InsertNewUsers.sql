
Insert INTO tenmo_user (username, password_hash, salt)
VALUES ('Andrew', 'F4vORt3dkJX5BMlxqKuQCZwB3sM=', '899dD1Us9fc=');
Insert INTO account (user_id, balance) VALUES (1001, 1000); 

Insert INTO tenmo_user (username, password_hash, salt)
OUTPUT Inserted.user_id
VALUES ('Walt', 'mpOFGmdogz8MZ0zPpdtRNfWL6m4=', 'ECBQGYxxsuE=');
Insert INTO account (user_id, balance) VALUES (1002, 1000); 

Insert INTO tenmo_user (username, password_hash, salt)
OUTPUT Inserted.user_id
VALUES('Sultan', 'JSpyPF6ntl0MDdDFx4mUzCD2/l8=', 'G+/9iErrZgs=');
Insert INTO account (user_id, balance) VALUES (1003, 1000); 

Insert INTO tenmo_user (username, password_hash, salt)
OUTPUT Inserted.user_id
VALUES ('Myron', 'aI+mmu6lVvD5Uwyqm1f+FlR2JXM=',	'PWuZXWX7GeM=');
Insert INTO account (user_id, balance) VALUES (1004, 1000);


Insert INTO tenmo_user (username, password_hash, salt)
OUTPUT Inserted.user_id
VALUES ('Dan', 'I1T40PFhQWm7uecPbFbM8Rhhtxo=', '6Obax59yhVE=');
Insert INTO account (user_id, balance) VALUES (1005, 1000); 