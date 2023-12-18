1. build the custom rule
2. place the dll in following the below:

In Studio versions prior to 2021.10:

For per-machine installations: %ProgramFiles%\UiPath\Studio\Rules
For per-user installations: %LocalAppData%\Programs\UiPath\Studio\Rules
In Studio 2021.10.6 and later:

For per-machine installations: %ProgramFiles%\UiPath\Studio\Rules\net6.0 (for rules targetting Windows and cross-platform projects) and %ProgramFiles%\UiPath\Studio\net461\Rules (for rules targetting Windows-legacy projects)
For per-user installations: %LocalAppData%\Programs\UiPath\Studio\Rules\net6.0 (for rules targetting Windows and cross-platform projects) and %LocalAppData%\Programs\UiPath\Studio\net461\Rules (for rules targetting Windows-legacy projects)

Alternatively, you can setup a custom location from settings.