CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE t_clipboard_entries (
    id text NOT NULL,
    "user" character varying(40) NOT NULL,
    content character varying(500) NOT NULL,
    time_stamp timestamp without time zone NOT NULL,
    content_max_length integer NOT NULL,
    CONSTRAINT "PK_t_clipboard_entries" PRIMARY KEY (id)
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20201106172508_InitialCreate', '3.1.8');

