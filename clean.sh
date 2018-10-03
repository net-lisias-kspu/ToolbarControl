#!/usr/bin/env bash

source ./CONFIG.inc

clean() {
	local DLL=$1.dll

	rm -f "./bin/Release/$DLL"
	rm -f "./bin/Debug/$DLL"
	rm -f "./GameData/$TARGETBINDIR/$DLL"
	rm -f "$LIB/$DLL"
	rm -f "${KSP_DEV}/GameData/$TARGETBINDIR/$DLL"
}

VERSIONFILE=$PACKAGE.version

rm -f "./GameData/$TARGETDIR/$VERSIONFILE"
rm -f "./GameData/$TARGETDIR/CHANGE_LOG.md"
rm -f "./GameData/$TARGETDIR/README.md"
rm -f "./GameData/$TARGETDIR/*.LICENSE"
for dll in $PACKAGE ; do
    clean $dll
done
