<?php
/**
 * Copyright (c) 2015 Thorbjørn Steen
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 */
class User
{
    const TABLE_NAME = 'Users';
    const ID = 'id';
    const USERNAME = 'username';

    public static function get() {
        if(isset($_POST['id'])){
            $whereValues = [
                self::ID => $_POST['id'],
            ];
        }

        $result = Database::select(self::TABLE_NAME, $whereValues);
        echo json_encode($result);
    }

}
