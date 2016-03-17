#ifndef MOVIETREE_H
#define MOVIETREE_H
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

struct MovieNode{
    int ranking;
    std::string title;
    int year;
    int quantity;
    bool isRed;
    MovieNode *parent;
    MovieNode *leftChild;
    MovieNode *rightChild;

    MovieNode(){};

    MovieNode(int in_ranking, std::string in_title, int in_year, int in_quantity, bool in_isRed)
    {
        ranking = in_ranking;
        title = in_title;
        year = in_year;
        quantity = in_quantity;
        leftChild = NULL;
    	rightChild = NULL;
        parent = NULL;
        isRed = true;
    }

};

class MovieTree
{
    public:
        MovieTree();
        virtual ~MovieTree();
        void printMovieInventory();
        int countMovieNodes();
        void deleteMovieNode(std::string title);
        void addMovieNode(int ranking, std::string title, int releaseYear, int quantity);
        void findMovie(std::string title);
        void rentMovie(std::string title);
        void printNode(MovieNode *node);
        void deleteAll(MovieNode *node);
        bool findNode(MovieNode *node, std::string title);
        int counter = 0;
        int totMov = 50;
        void initJson(std::string type,std::string title, json_object *jMovieAdd[]);
        json_object *jObj = json_object_new_object();
        int countLongestPath();
        //use this to return the json object from the class when you are ready to write it to a file
        json_object* getJsonObject;
        MovieNode *root;
        ofstream myFile;
        MovieNode *foundMovie;
        int blackVal = 0;

    protected:
    private:
        void DeleteAll(MovieNode * node); //use this for the post-order traversal deletion of the tree
        void printMovieInventory(MovieNode * node, json_object * traverseLog);
        void searchMovieNodes(string title);
        void rbAddFixup(MovieNode * node); // called after insert to fix tree
        void leftRotate(MovieNode * x);
        void rbDelete(MovieNode * z);
        void rightRotate(MovieNode * x);
        void rbDeleteFixup(MovieNode * node);
        void rbTransplant(MovieNode * u, MovieNode * v);
        int rbValid(MovieNode * node);
        int countMovieNodes(MovieNode *node);
        int countLongestPath(MovieNode *node);
        MovieNode* searchMovieTree(MovieNode * node, std::string title, json_object * traverseLog);
        json_object *dltFind[50];
        bool found = true;
        int cont = 0;
        int i = 0;

        MovieNode *nil;

        // Count of how many operations we have done.
        int opCount;
        //including the json_object in the class makes it global within the class, much easier to work with
        json_object * Assignment6Output;


};

#endif // MOVIETREE_H
