#include <iostream>
#include <json/json.h>
#include <fstream>
#include "MovieTree.h"
#include <string>
#include <sstream>
#include <stdio.h>
#include <stdlib.h>
#include <istream>

using namespace std;

void PrintMainMenu(){
    cout<<"======Main Menu====="<<endl;
    cout<<"1. Rent a movie"<<endl;
    cout<<"2. Print the inventory"<<endl;
    cout<<"3. Delete a movie"<<endl;
    cout<<"4. Count the movies"<<endl;
    cout<<"5. Count the longest path"<<endl;
    cout<<"6. Quit"<<endl;
}

int main(int argc, char *argv[])
{
    json_object *jMovieAdd[50];
    MovieTree *mov = new MovieTree();

    string line;
    int ranking;
    string title;
    int year;
    int quantity;
    int response;
    string srch;
    int strCounter = 0;
    string strTitles[50];
    int i = 0;
    string add = "add";




    mov->myFile.open("Assignment7Output.txt");

    ifstream in;
    in.open(argv[1]);
    if(in.is_open()){
        while(getline(in,line)){

            size_t pos = line.find(',');
            ranking = stoi(line.substr(0,pos));
            line = line.substr(pos+1);

            pos = line.find(',');
            title = line.substr(0,pos);
            line = line.substr(pos+1);

            pos = line.find(',');
            year = stoi(line.substr(0,pos));
            line = line.substr(pos+1);

            quantity = stoi(line.substr(0,pos));

            mov->addMovieNode(ranking, title, year, quantity);
            i++;

        }
    }
    bool k = false;
    while(response != 6){ //Works the main menu and options
        PrintMainMenu();
        cin>>response;
        if(response == 1){
            cout<<"Enter title:"<<endl;
            cin.ignore();
            getline(cin,srch);
            mov->rentMovie(srch);
            if(mov->foundMovie->quantity==0)
                mov->deleteMovieNode(srch);
            srch = "";
        }
        else if(response == 2){
            mov->printMovieInventory();
        }
        else if(response == 3){
            cout<<"Enter title:"<<endl;
            cin.ignore();
            getline(cin,srch);
            mov->deleteMovieNode(srch);
            srch = "";
        }
        else if(response == 4){
            mov->countMovieNodes();
        }
        else if(response == 5){
            int c = 0;
            string p;
            c = mov->countLongestPath();
            p = to_string(c);
            json_object *jMovieAdd[1];
            mov->initJson("height", p, jMovieAdd);
        }
    }
    cout<<"Goodbye!"<<endl;
    mov->myFile << json_object_to_json_string_ext(mov->getJsonObject, JSON_C_TO_STRING_PRETTY)<<endl;
    mov->myFile.close();
    mov->deleteAll(mov->root);
    return 0;
}

