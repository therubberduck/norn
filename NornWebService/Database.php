<?php
/**
 * Copyright (c) 2015 Thorbjørn Steen
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 */
class Database
{
    const SERVERNAME = 'localhost';
    const USERNAME = 'rubberdu_norn';
    const PASSWORD = 'dACYwU74jDCv';
    const DBNAME = 'rubberdu_norn';

    public static function delete($tablename, $whereParams) {
        //Compile query
        $whereString = "";
        foreach($whereParams as $key => $value) {
            $whereString .= " AND " . $key . " = '" . $value . "'";
        }
        $whereString = substr($whereString, 5);
        $query = "DELETE FROM " . $tablename . "
            WHERE " . $whereString;

        if($_POST['debug'] == 1){
            echo "Attempt query: " . $query . "<br>";
        }

        //Open database connection
        $conn = new mysqli(self::SERVERNAME, self::USERNAME, self::PASSWORD, self::DBNAME);
        if($conn->connect_error) {
            die("Connection failed: " . $conn->connect_error);
        }

        //Make query
        if($conn->query($query) == TRUE) {
            if($_POST['debug'] == 1){
                echo "Query Successful";
            }

            $affected_rows = $conn->affected_rows;
            //Close connection
            $conn->close();
            return $affected_rows;
        }
        else {
            echo "Error: " . $query . "<br>" . $conn->error;
        }

        //Close connection
        $conn->close();
    }

    public static function insert($tablename, $valueParams) {
        //Compile query
        $keys = "";
        $values = "";

        foreach($valueParams as $key => $value) {
            $keys .= ", " . $key;
            if(is_int($value) || is_bool($value)){
                $values .= ", " . $value . "";
            }
            else {
                $values .= ", '" . $value . "'";
            }

        }
        $keys = substr($keys, 2);
        $values = substr($values, 2);

        $query = "INSERT INTO " . $tablename . " (" . $keys . ")
            VALUES(" . $values . ")";

        if($_POST['debug'] == 1){
            echo "Attempt query: " . $query . "<br>";
        }

        //Open database connection
        $conn = new mysqli(self::SERVERNAME, self::USERNAME, self::PASSWORD, self::DBNAME);
        if($conn->connect_error) {
            die("Connection failed: " . $conn->connect_error);
        }

        //Make query
        if($conn->query($query) == TRUE) {
            if($_POST['debug'] == 1){
                echo "Query Successful";
            }

            $last_id = $conn->insert_id;
            //Close connection
            $conn->close();
            return $last_id;
        }
        else {
            echo "Error: " . $query . "<br>" . $conn->error;
        }

        //Close connection
        $conn->close();
    }

    public static function select($tablename, $whereParams) {
        //Compile query
        $query = "SELECT * FROM " . $tablename;

        //Add optional where clause
        if(isset($whereParams)){
            $whereString = "";
            foreach($whereParams as $key => $value) {
                $whereString .= " AND " . $key . " = '" . $value . "'";
            }
            $whereString = substr($whereString, 5);

            $query .= " WHERE " . $whereString;
        }

        if($_POST['debug'] == 1){
            echo "Attempt query: " . $query . "<br>";
        }

        //Open database connection
        $conn = new mysqli(self::SERVERNAME, self::USERNAME, self::PASSWORD, self::DBNAME);
        if($conn->connect_error) {
            die("Connection failed: " . $conn->connect_error);
        }

        //Make query
        if($result = $conn->query($query)) {
            if($_POST['debug'] == 1){
                echo "Query Successful";
            }
            $result_array = array();
            while($row = $result->fetch_array(MYSQL_ASSOC)){
                $result_array[] = $row;
            }
            //Close connection
            $result->close();
            $conn->close();
            return $result_array;
        }
        else {
            echo "Error: " . $query . "<br>" . $conn->error;
        }

        //Close connection
        $conn->close();
    }

    public static function update($tablename, $valueParams, $whereParams) {
        //Compile query
        $valuesString = "";

        foreach($valueParams as $key => $value) {
            $valuesString .= ", " . $key . " = '" . $value . "'";
        }
        $valuesString = substr($valuesString, 2);

        $whereString = "";
        foreach($whereParams as $key => $value) {
            $whereString .= " AND " . $key . " = '" . $value . "'";
        }
        $whereString = substr($whereString, 5);

        $query = "UPDATE " . $tablename . "
            SET " . $valuesString . "
            WHERE " . $whereString;

        if($_POST['debug'] == 1){
            echo "Attempt query: " . $query . "<br>";
        }

        //Open database connection
        $conn = new mysqli(self::SERVERNAME, self::USERNAME, self::PASSWORD, self::DBNAME);
        if($conn->connect_error) {
            die("Connection failed: " . $conn->connect_error);
        }

        //Make query
        if($conn->query($query) == TRUE) {
            if($_POST['debug'] == 1){
                echo "Query Successful";
            }

            $affected_rows = $conn->affected_rows;
            //Close connection
            $conn->close();
            return $affected_rows;
        }
        else {
            echo "Error: " . $query . "<br>" . $conn->error;
        }

        //Close connection
        $conn->close();
    }

    public static function select_query($query) {
        if($_POST['debug'] == 1){
            echo "Attempt query: " . $query . "<br>";
        }

        $conn = new mysqli(self::SERVERNAME, self::USERNAME, self::PASSWORD, self::DBNAME);
        if($conn->connect_error) {
            die("Connection failed: " . $conn->connect_error);
        }

        if($result = $conn->query($query)) {
            if($_POST['debug'] == 1){
                echo "Query Successful";
            }
            $result_array = array();
            while($row = $result->fetch_array(MYSQL_ASSOC)){
                $result_array[] = $row;
            }
            //Close connection
            $result->close();
            $conn->close();
            return $result_array;
        }
        else {
            echo "Error: " . $query . "<br>" . $conn->error;
        }

        $conn->close();
    }
}
