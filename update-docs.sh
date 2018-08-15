#!/usr/bin/env bash

./bin/fetch-configlet
./bin/configlet generate .
find ./config/patches -type f -name *.patch -exec git apply {} \;