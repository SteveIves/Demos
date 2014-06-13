
MUST BE LOGGED IN TO AN ADMINISTRATOR ACCOUNT

USE X64 OR SYNBACKUP WONT WORK!!!

START WORKBANCH AS ADMINISTRATOR OR BACKUP WILL NOT WORK

Before this example can be used, the SynBackup utility must be enabled:

        Windows:        synbackup -c            (Creates DBLDIR:synbackup.cfg)
        Unix:           Refer to the Synergy/DE Tools manual

64-bit only???  32-bit synbackup -c says to use the 64-bit utility





SynBackup responses:

Activate        synbackup -c            Backup feature has been enabled
                                        Backup mode set to Off

                                        Shared memory segment already exists

Deactivate      synbackup -d            Backup feature has been disabled

                                        Backup feature has already been disabled

                                        DeleteFile error 32: The process cannot access the file because it is being used by another process.
                                        Unable to disable backup feature

Check           synbackup -q            Current backup mode is Off

                                        Current backup mode is On

                                        Current backup mode is Pending

                                        Backup feature has not been enabled

