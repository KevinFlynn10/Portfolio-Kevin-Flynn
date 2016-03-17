#include <iostream>
#include <json/json.h>
#include <string.h>
#include <string>
#include <stdio.h>
#include <fstream>
#include "MovieTree.h"
#include <fstream>
#include <istream>
using namespace std;

MovieTree::MovieTree(){
    nil = new MovieNode;
    root = nil;
    root->parent = nil;
    nil->isRed = false;

}
MovieTree::~MovieTree(){

}
void MovieTree::searchMovieNodes(string title){
    i=0;
    MovieNode *temp = new MovieNode;

    if(root!=nil){ //tree is not empty
        MovieNode *y = nil; 
        MovieNode *x = root; 
        MovieNode *z = temp; //z is temp node
        cout<<root->title<<endl;
       //assume we don't have an empty tree, which means that root isn't nil
        const char * charTitle = title.c_str(); // takes in title parameter
        while(x->title != title){ //while x is not nil
            y = x; //y is equal to x. meaning temp node is equal to x
            string titleX = x->title;
            const char * charTitleX = titleX.c_str();

            if(strcmp(charTitleX,charTitle) > 0){ //if X title is alphabetically larger than title param
                dltFind[i] = json_object_new_string(x->title.c_str());
                i++;
                x = x->leftChild; //x is equal to left child
                cout<<"> "<<x->title<<endl;
            }
            if(strcmp(charTitleX,charTitle) <= 0){//if X title is alphabetically smaller or equal to title param
                dltFind[i] = json_object_new_string(x->title.c_str());
                i++;
                x = x->rightChild; // x is equal to right child
                cout<<"< "<<x->title<<endl;
            }
        }
        dltFind[i] = json_object_new_string(title.c_str());
        i++;
    }
}
void MovieTree::initJson(string type, string title, json_object *jMovieAdd[]){
    cont++;
    string c = to_string(cont);
    const char *pchar = c.c_str();
    json_object *jTitle = json_object_new_string(title.c_str());
    json_object *jMovie = json_object_new_array();
    for(int j = 0; j<i;j++){
            json_object_array_add(jMovie, jMovieAdd[j]);
        }
    if (type == "add"){
        json_object *jAdd = json_object_new_string("add");
        json_object *jOp1 = json_object_new_object();
        json_object_object_add(jOp1, "operation", jAdd);
        json_object_object_add(jOp1, "parameter", jTitle);
        json_object_object_add(jOp1, "output", jMovie);
        json_object_object_add(jObj, pchar, jOp1);
    }
    //the delete operation. Create the json object for delete
    else if(type == "delete"){
        json_object *jOp2 = json_object_new_object();
        json_object *jDelete = json_object_new_string("delete");
        json_object_object_add(jOp2, "operation", jDelete);
        json_object_object_add(jOp2, "parameter", jTitle);
        json_object_object_add(jOp2, "output", jMovie);
        json_object_object_add(jObj, pchar, jOp2);
    }

    else if(type == "rent"){
        json_object *jOp3 = json_object_new_object();
        json_object *jRent = json_object_new_string("rent");
        json_object_object_add(jOp3, "operation", jRent);
        json_object_object_add(jOp3, "parameter", jTitle);
        json_object_object_add(jOp3, "output", jMovieAdd[0]);
        json_object_object_add(jObj, pchar, jOp3);
    }
    else if(type == "traverse"){
        json_object *jOp4 = json_object_new_object();
        json_object *jTraverse = json_object_new_string("traverse");
        json_object_object_add(jOp4, "operation", jTraverse);
        json_object_object_add(jOp4, "output", jMovie);
        json_object_object_add(jObj, pchar, jOp4);
    }
     else if(type == "count"){
        json_object *jOp5 = json_object_new_object();
        json_object *jCount = json_object_new_string("count");
        json_object_object_add(jOp5, "operation", jCount);
        json_object_object_add(jOp5, "output", jTitle);
        json_object_object_add(jObj, pchar, jOp5);
    }
    else if(type == "height"){
        json_object *jOp5 = json_object_new_object();
        json_object *jCount = json_object_new_string("height");
        json_object_object_add(jOp5, "operation", jCount);
        json_object_object_add(jOp5, "output", jTitle);
        json_object_object_add(jObj, pchar, jOp5);
    }

    getJsonObject = jObj;
}
void MovieTree::deleteAll(MovieNode *x){
    if (x != nil){
        deleteAll(x->leftChild);
        deleteAll(x->rightChild);
        delete x;
    }
}
void MovieTree::deleteMovieNode(string title){
    counter = 0;
    found = findNode(root, title);
    if(found == true){
        MovieTree::searchMovieNodes(title);
        MovieTree::initJson("delete", title, dltFind);
        i=0;
        MovieNode *x = foundMovie;
        MovieNode *y = x;
        MovieNode *z = foundMovie->parent;
        if(foundMovie->rightChild == nil && foundMovie->leftChild == nil){
            if(z->rightChild == x){
                z->rightChild = nil;
                delete foundMovie;
            }
            else if(z->leftChild == foundMovie){
                z->leftChild = nil;
                delete foundMovie;
            }
        }
        else if(x->rightChild == nil && x->leftChild!=nil){
            if(z->rightChild == foundMovie){
                z->rightChild = x->leftChild;
                delete foundMovie;
            }
            else if(z->leftChild == foundMovie){
                z->leftChild = x->leftChild;
                delete foundMovie;
            }
        }
        else if(x->rightChild != nil && x->leftChild==nil){
            if(z->rightChild == foundMovie){
                z->rightChild = x->rightChild;
                delete foundMovie;
            }
            else if(z->leftChild == foundMovie){
                z->leftChild = x->rightChild;
                delete foundMovie;
            }
        }
        else if(x->rightChild != nil && x->leftChild!=nil){
            MovieNode *chck = foundMovie->rightChild;
            if(foundMovie->rightChild==nil && foundMovie->leftChild==nil){
                foundMovie = chck;
                delete chck;
                foundMovie->rightChild = nil;
            }
            else{ // right child has children
            //if the node's right child has a left child
            // Move all the way down left to locate smallest element

                    if(foundMovie->rightChild->leftChild != nil){

                        MovieNode* lcurr;
                        MovieNode* lcurrp;
                        lcurrp = foundMovie->rightChild;
                        lcurr = foundMovie->rightChild->leftChild;
                        while(lcurr->leftChild != nil){
                            lcurrp = lcurr;
                            lcurr = lcurr->leftChild;
                        }
                        foundMovie->title = lcurr->title;
                        delete lcurr;
                        lcurrp->leftChild = nil;
                    }
                    else{
                        MovieNode* tmp;
                        tmp = foundMovie->rightChild;
                        foundMovie->title = tmp->title;
                        foundMovie->rightChild = tmp->rightChild;
                        delete tmp;
                }
            }
        }
        totMov -= 1;
    }
    else if(found == false){
        cout<<"Movie not found"<<endl;
    }
}

void MovieTree::leftRotate(MovieNode * x){
    MovieNode *y;
    y = x->rightChild;
    x->rightChild = y->leftChild;
    if (y->leftChild != nil){
        y->leftChild->parent = x;
    }
    y->parent = x->parent;
    if (x->parent == nil){
        root = y;
    }
    else{
        if (x == (x->parent)->leftChild){
            x->parent->leftChild = y;
        }
        else {
            x->parent->rightChild = y;
        }
    }
    y->leftChild = x;
    x->parent = y;
}
void MovieTree::rightRotate(MovieNode * y){
    MovieNode *x = new MovieNode;
    x = y->leftChild;
    y->leftChild = x->rightChild;
    if(x->rightChild != nil){
        x->rightChild->parent = y;
    }
    x->parent = y->parent;
    if(y->parent == nil){
        root = x;
    }
    else if(y == y->parent->leftChild){
        y->parent->leftChild = x;
    }
    else{
        y->parent->rightChild = x;
    }
    x->rightChild = y;
    y->parent = x;
}
int MovieTree::countLongestPath(MovieNode *node){
    if(node == nil){
        return -1;
    }
    if(countLongestPath(node->leftChild)>countLongestPath(node->rightChild)){
        return 1 + countLongestPath(node->leftChild);
    }
    else{
        return 1 + countLongestPath(node->rightChild);
    }
}

void MovieTree::rbAddFixup(MovieNode * node){
    /*Assume node exists in tree T called nil. It is empty node maintained for red-black structure.*/
    MovieNode *y;
    node->leftChild = nil;
    node->rightChild = nil;
    
    /* Now restore the red-black property */
    node->isRed = true;
    while (node != root && node->parent->isRed == true && node->parent->parent != nil && node->parent != nil) {
       if (node->parent == node->parent->parent->leftChild) {
           /* If x's parent is a left, y is x's right 'uncle' */
           y = node->parent->parent->rightChild;
            if (y->isRed == true) {
              /* case 1 - change the colors */
              node->parent->isRed = false;
              y->isRed = false;
              node->parent->parent->isRed = true;
              /* Move x up the tree */
              node = node->parent->parent;
            }
            else {
             /* y is a black node */
              if ( node == node->parent->rightChild ) {
                 /* and x is to the right */
                  /* case 2 - move x up and rotate */
                  node = node->parent;
                  leftRotate(node);
              }
              /* case 3 */
              node->parent->isRed = false;
              node->parent->parent->isRed = true;
              rightRotate(node->parent->parent );
          }
      }
      else {
          /* repeat the "if" part with right and left exchanged */
          y = node->parent->parent->leftChild;
            if ( y->isRed == true ) {
              /* case 1 - change the colors */
              node->parent->isRed = false;
              y->isRed = false;
              node->parent->parent->isRed = true;
              /* Move x up the tree */
              node = node->parent->parent;
          }
          else {
              /* y is a black node */
              if ( node == node->parent->leftChild ) {
                  /* and x is to the right */
                  /* case 2 - move x up and rotate */
                  node = node->parent;
                  rightRotate(node);
              }
              /* case 3 */
              node->parent->isRed = false;
              node->parent->parent->isRed = true;
              leftRotate(node->parent->parent);
          }
      }
  }
  /* Color the root black */
    root->isRed = false;
}

int MovieTree::countMovieNodes(){
    string c = to_string(totMov);
    json_object *jMovieAdd[1];
    jMovieAdd[0] = json_object_new_string(c.c_str());
    i++;
    MovieTree::initJson("count",c,jMovieAdd);
    i=0;
}

void MovieTree::printNode(MovieNode *x){
    if(x->leftChild != nil){
        printNode(x->leftChild);
    }
    dltFind[i] = json_object_new_string(x->title.c_str());
    cout<<x->title<<endl;
    i++;

    if(x->rightChild != nil){
        printNode(x->rightChild);
    }
}
bool MovieTree::findNode(MovieNode *x, string title){
    
    if(x->title == title){
        foundMovie = x;
        return true;
    }
    if(x->leftChild != nil){
        findNode(x->leftChild,title);
    }
    counter++;
    if(x->rightChild != nil){
        dltFind[i] = json_object_new_string(x->title.c_str());
        findNode(x->rightChild,title);
    }
    if(counter >= totMov){
        return false;
    }
}
void MovieTree::printMovieInventory(){
    printNode(root);
    string s = "";
    MovieTree::initJson("traverse",s,dltFind);
    i = 0;
}
void MovieTree::addMovieNode(int ranking, string title, int releaseYear, int quantity){
    MovieNode *temp = new MovieNode;
    json_object *jMovieAdd[50];
    i=0;
    temp->rightChild = nil;
    temp->leftChild = nil;
    temp->parent = nil;
    temp->quantity = quantity;
    temp->ranking = ranking;
    temp->title = title;
    temp->year = releaseYear;
    
    if(root == nil){ //if head is nil meaning tree is empty
        jMovieAdd[i] = json_object_new_string(temp->title.c_str());
        MovieTree::initJson("add", title, jMovieAdd);
        root = temp;
        root->parent = nil;
        root->rightChild = nil;
        root->leftChild = nil;
    }
    else{ //tree is not empty
        MovieNode *y = nil; 
        MovieNode *x = root; 
        MovieNode *z = temp; //z is temp node

       //assume we don't have an empty tree, which means that root isn't nil
        const char * charTitle = title.c_str(); // takes in title parameter

        while(x != nil){ //while x is not nil
            y = x; //y is equal to x. meaning temp node is equal to x
            string titleX = x->title;
            const char * charTitleX = titleX.c_str();

            if(strcmp(charTitleX,charTitle) > 0){ //if X title is alphabetically larger than title param
                jMovieAdd[i] = json_object_new_string(x->title.c_str());
                i++;
                x = x->leftChild; //x is equal to left child
            }
            if(strcmp(charTitleX,charTitle) <= 0){//if X title is alphabetically smaller or equal to title param
                jMovieAdd[i] = json_object_new_string(x->title.c_str());
                i++;
                x = x->rightChild; // x is equal to right child
            }
        }
        z->parent = y; //temp node parent is equal to y. which should at this point be equal to x
        string titleY = y->title;
        const char * charTitleY = titleY.c_str();

        if(strcmp(charTitleY,charTitle) > 0){ ///if Y title is alphabetically larger than title param
            y->leftChild = z; //set y which is equal to x left child = temp
            z->leftChild = nil; 
            z->rightChild = nil;
        }
        else{ //equivalent conditional as (strcmp(charTitleY,charTitle) <= 0)
            y->rightChild = z; //set y which is equal to x right child = temp
            z->leftChild = nil;
            z->rightChild = nil;
        }
        MovieTree::rbAddFixup(temp);
        MovieTree::initJson("add", title, jMovieAdd);

        i = 0;
    }
}

void MovieTree::rentMovie(string title){
    counter = 0;
    json_object *jMovieAdd[1];
    found = findNode(root,title);
    if(found == true && foundMovie->quantity > 0){
        foundMovie->quantity -= 1;
        cout<<foundMovie->title<<endl;
        jMovieAdd[0] = json_object_new_string(to_string(foundMovie->quantity).c_str());
        i++;
        MovieTree::initJson("rent", title, jMovieAdd);
        i = 0;
        //delete jMovieAdd;
        cout<<"Movie has been rented."<<endl;
        cout<<"Movie Info:"<<endl;
        cout<<"==========="<<endl;
        cout<<"Ranking:"<<foundMovie->ranking<<endl;
        cout<<"Title:"<<foundMovie->title<<endl;
        cout<<"Year:"<<	foundMovie->year<<endl;
        cout<<"Quantity:"<<foundMovie->quantity<<endl;
    }
    else if(found == true && foundMovie->quantity == 0){
        cout<<"Movie out of stock."<<endl;
    }
    else if(found == false){
        cout<<"Movie not found."<<endl;
    }
}
int MovieTree::rbValid(MovieNode * node){
    int lh = 0;
    int rh = 0;

    // If we are at a nil node just return 1
    if (node == nil)
        return 1;

    else
    {
        // First check for consecutive red links.
        if (node->isRed)
        {
            if(node->leftChild->isRed || node->rightChild->isRed)
            {
                cout << "This tree contains a red violation" << endl;
                return 0;
            }
        }

        // Check for valid binary search tree.
        if ((node->leftChild != nil && node->leftChild->title.compare(node->title) > 0) || (node->rightChild != nil && node->rightChild->title.compare(node->title) < 0))
        {
            cout << "This tree contains a binary tree violation" << endl;
            return 0;
        }

        // Deteremine the height of left and right children.
        lh = rbValid(node->leftChild);
        rh = rbValid(node->rightChild);

        // black height mismatch
        if (lh != 0 && rh != 0 && lh != rh)
        {
            cout << "This tree contains a black height violation" << endl;
            return 0;
        }

        // If neither height is zero, incrament if it if black.
        if (lh != 0 && rh != 0)
        {
                if (node->isRed == true){
                    return lh;
                }
                else{
                    return lh+1;
                }
        }

        else
        return 0;

    }
}
