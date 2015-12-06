<?php
/**
 * Copyright (c) 2015 Thorbjørn Steen
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 */

include_once 'Webservice.php';

if(isset($_POST['task'])){
    Webservice::call();
}
else {
    echo "getContent: id(optional)<br>";
    echo "getContent: title<br>";
    echo "addContent: typeid, title, content, visible<br>";
    echo "editContent: id, typeid, title, content, visible<br>";
    echo "deleteContent: id<br>";
    echo "getType: id(optional)<br>";
    echo "addType: title<br>";
    echo "editType: id, title<br>";
    echo "deleteType: id<br>";
    echo "getContentOnUser: userid, number, visible(optional)<br>";
    echo "addContentToUser: contentid, userid, number, detail<br>";
    echo "editContentOnUser: id, number, detail<br>";
    echo "removeContentFromUser: id<br>";
    echo "getUser: id(optional)<br>";
}