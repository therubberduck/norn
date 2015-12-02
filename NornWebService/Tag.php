<?php
/**
 * Copyright (c) 2015 Thorbjørn Steen
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 */
class Tag
{
    const TABLE_NAME = 'Tags';
    const PARENTID = 'parentid';
    const CHILDID = 'childid';

    public static function add($parentid, $childid) {
        $values = [
            self::PARENTID => $parentid,
            self::CHILDID => $childid,
        ];

        Database::insert(self::TABLE_NAME, $values);
    }

    public static function remove($parentid) {
        $where = [
            self::PARENTID => $parentid,
        ];

        Database::delete(self::TABLE_NAME, $where);
    }
}
