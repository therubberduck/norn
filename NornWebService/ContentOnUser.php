<?php
/**
 * Copyright (c) 2015 Thorbjørn Steen
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 */
class ContentOnUser
{
    const TABLE_NAME = 'ContentOnUsers';
    const ID = 'id';
    const CONTENTID = 'contentid';
    const USERID = 'userid';
    const NUMBER = 'number';
    const DETAIL = 'detail';

    public static function get() {
        include_once 'Content.php';

        $whereString = "cu." . self::USERID . "='" .$_POST['userid'] . "'";
        if(isset($_POST['visible']) && $_POST['visible']){
            $whereString .= " AND c." . Content::VISIBLE . "='" .$_POST['visible'] . "'";
        }

        $query = "SELECT cu." . self::ID . ", cu." . self::CONTENTID . ", cu." . self::NUMBER . ", cu." . self::DETAIL . ", c." . Content::TITLE . "
                FROM " . self::TABLE_NAME . " AS cu INNER JOIN " . Content::TABLE_NAME . " AS c ON cu." . self::CONTENTID . " = c." . Content::ID . "
                WHERE " . $whereString;

        $result = Database::select_query($query);
        echo json_encode($result);
    }

    public static function add() {
        $values = [
            self::CONTENTID => $_POST['contentid'],
            self::USERID => $_POST['userid'],
            self::NUMBER => $_POST['number'],
            self::DETAIL => $_POST['detail']
        ];

        Database::insert(self::TABLE_NAME, $values);
    }

    public static function edit() {
        $values = [
            self::NUMBER => $_POST['number'],
            self::DETAIL => $_POST['detail']
        ];
        $where = [
            self::ID => $_POST['id']
        ];

        Database::update(self::TABLE_NAME, $values, $where);
    }

    public static function remove() {
        $where = [
            self::ID => $_POST['id']
        ];

        Database::delete(self::TABLE_NAME, $where);
    }
}
