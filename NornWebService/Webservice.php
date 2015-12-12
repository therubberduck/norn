<?php
/**
 * Copyright (c) 2015 Thorbjørn Steen
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 */
include_once 'Database.php';

class Webservice
{
    public static function call(){
        $task = $_POST['task'];
        if($task == 'getContent' && isset($_POST['title'])) {
            include_once 'Content.php';
            Content::getFromTitle();
        }
        else if($task == 'getContent') {
            include_once 'Content.php';
            Content::get();
        }
        else if($task == 'addContent') {
            include_once 'Content.php';
            Content::add();
        }
        else if($task == 'editContent'){
            include_once 'Content.php';
            Content::edit();
        }
        else if($task == 'deleteContent'){
            include_once 'Content.php';
            Content::remove();
        }
        else if($task == 'getType') {
            include_once 'Type.php';
            Type::get();
        }
        else if($task == 'addType'){
            include_once 'Type.php';
            Type::add();
        }
        else if($task == 'editType'){
            include_once 'Type.php';
            Type::edit();
        }
        else if($task == 'deleteType'){
            include_once 'Type.php';
            Type::remove();
        }
        else if($task == 'getContentOnUser'){
            include_once 'ContentOnUser.php';
            ContentOnUser::get();
        }
        else if($task == 'addContentToUser'){
            include_once 'ContentOnUser.php';
            ContentOnUser::add();
        }
        else if($task == 'editContentOnUser'){
            include_once 'ContentOnUser.php';
            ContentOnUser::edit();
        }
        else if($task == 'removeContentFromUser'){
            include_once 'ContentOnUser.php';
            ContentOnUser::remove();
        }
        else if($task == 'useContentOnUser'){
            include_once 'ContentOnUser.php';
            ContentOnUser::useContentOnUser();
        }
        else if($task == 'getUser'){
            include_once 'User.php';
            User::get();
        }
        else {
            echo "Task not recognized.<br>";
        }
    }

}