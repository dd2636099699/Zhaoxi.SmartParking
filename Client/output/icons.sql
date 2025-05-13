/*
 Navicat Premium Data Transfer

 Source Server         : data
 Source Server Type    : SQLite
 Source Server Version : 3021000
 Source Schema         : main

 Target Server Type    : SQLite
 Target Server Version : 3021000
 File Encoding         : 65001

 Date: 23/02/2021 20:34:19
*/

PRAGMA foreign_keys = false;

-- ----------------------------
-- Table structure for icons
-- ----------------------------
DROP TABLE IF EXISTS "icons";
CREATE TABLE "icons" (
  "_id" INTEGER NOT NULL COLLATE RTRIM PRIMARY KEY AUTOINCREMENT,
  "icon" text
);

-- ----------------------------
-- Records of icons
-- ----------------------------
INSERT INTO "icons" VALUES (1, 'e68f');
INSERT INTO "icons" VALUES (2, 'e635');
INSERT INTO "icons" VALUES (3, 'e603');
INSERT INTO "icons" VALUES (4, 'e601');
INSERT INTO "icons" VALUES (5, 'e60a');
INSERT INTO "icons" VALUES (6, 'e648');
INSERT INTO "icons" VALUES (7, 'e6bf');
INSERT INTO "icons" VALUES (8, 'e613');
INSERT INTO "icons" VALUES (9, 'e6df');
INSERT INTO "icons" VALUES (10, 'e625');
INSERT INTO "icons" VALUES (11, 'eaa0');
INSERT INTO "icons" VALUES (12, 'e658');
INSERT INTO "icons" VALUES (13, 'e618');
INSERT INTO "icons" VALUES (14, 'e602');
INSERT INTO "icons" VALUES (15, 'e6b8');
INSERT INTO "icons" VALUES (16, 'e6a9');
INSERT INTO "icons" VALUES (17, 'ea2e');
INSERT INTO "icons" VALUES (18, 'e62a');
INSERT INTO "icons" VALUES (19, 'e605');
INSERT INTO "icons" VALUES (20, 'e609');
INSERT INTO "icons" VALUES (21, 'e81d');
INSERT INTO "icons" VALUES (22, 'e600');
INSERT INTO "icons" VALUES (23, 'e694');
INSERT INTO "icons" VALUES (24, 'e7e6');
INSERT INTO "icons" VALUES (25, 'e653');
INSERT INTO "icons" VALUES (26, 'e63e');
INSERT INTO "icons" VALUES (27, 'e608');

-- ----------------------------
-- Auto increment value for icons
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 27 WHERE name = 'icons';

PRAGMA foreign_keys = true;
