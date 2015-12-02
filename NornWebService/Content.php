<?php
/**
 * Copyright (c) 2015 Thorbjørn Steen
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 */
include_once "Tag.php";

class Content
{
    const TABLE_NAME = 'Content';
    const ID = 'id';
    const TYPEID = 'typeid';
    const TITLE = 'title';
    const CONTENT = 'content';
    const VISIBLE = 'visible';

    public static function get($id = 0) {
        if(isset($_POST['id'])){
            $whereValues = [
                self::ID => $_POST['id'],
            ];
        }
        if($id != 0){
            $whereValues = [
                self::ID => $id,
            ];
        }

        $result = Database::select(self::TABLE_NAME, $whereValues);
        echo json_encode($result);
    }

    public static function add() {
        $values = [
            self::TYPEID => intval($_POST['typeid']),
            self::TITLE => $_POST ['title'],
            self::CONTENT => $_POST['content'],
            self::VISIBLE => $_POST['visible'] == 'True',
        ];

        $newId = Database::insert(self::TABLE_NAME, $values);

        Content::get($newId);
        //TODO detect tags, and add them
        //Tag::add($newId, *);
    }

    public static function edit() {
        $values = [
            self::TYPEID => $_POST['typeid'],
            self::TITLE => $_POST ['title'],
            self::CONTENT => $_POST['content'],
            self::VISIBLE => $_POST['visible'],
        ];
        $where = [
            self::ID => $_POST['id'],
        ];

        Database::update(self::TABLE_NAME, $values, $where);

        Tag::remove($_POST['id']);
        //TODO detect tags, and add them
        //Tag::add($_POST['id'], *);
    }

    public static function remove() {
        $where = [
            self::ID => $_POST['id'],
        ];

        Database::delete(self::TABLE_NAME, $where);
        Tag::remove($_POST['id']);
    }
}
