<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1026838)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Blazor Reports  - How to Enable Custom Custom ICU Interop (.NET Blazor WASM) for Complex Typography

This example incorporates advanced ICU capabilities in DevExpress-powered Blazor WASM apps through custom native wrappers/ICU data files and integrates them with DevExpress ICU interop.

This configuration/description addresses the following:

* How to prevent WASM trimming of advanced ICU functions.
* How to add a native C wrapper to your Blazor WASM project.
* How to supply full ICU data files required for complex script rendering.
* How to implement and register a custom ICU interop provider compatible with DevExpress product libraries.
 
With this strategy, your DevExpress-powered Blazor WASM application can work with complex typography, bidirectional text, advanced script detection, and other ICU-powered features.

## When Custom ICU Interop is Required

The default WASM toolchain strips any unused native ICU functions. If your application processes text that requires additional ICU features (BiDi runs, script runs, break iterators), these functions must be preserved manually.

The most reliable way to force the compiler to retain them is to expose the required ICU methods through a C wrapper. This wrapper marks the methods as used and prevents trimming.

## Implementation Details

### Add a Native C Wrapper

Create a wrapper file (for example, native/wrapper.c) and include all ICU functions you intend to use. Each wrapper method must directly call the corresponding ICU export.

```xml
<ItemGroup>
    <NativeFileReference Include="native\wrapper.c" />
</ItemGroup>
```

The following code snippet illustrates the basic pattern for creating a C wrapper around ICU functions:

```c
#include <stdio.h>
#include <dirent.h>
// Declare the original ICU function with extern.
extern int ubidi_countRuns(void* pBiDi, int* errorCode);
// Define a _wrapper function that calls it.
int ubidi_countRuns_wrapper(void* pBiDi, int* errorCode) {
    return ubidi_countRuns(pBiDi, errorCode);
}
...
```

File to review: [wrapper.c](BlazorWasmCustomIcuInteropExample/BlazorWasmCustomIcuInteropExample.Client/Native/wrapper.c)

### Supply ICU Data Required for WASM

The .NET SDK strips ICU data files and does not contain an option to include full data. For correct interop, you must download the full ICU data package that matches the ICU version used by your .NET SDK.

Download the corresponding archive from GitHub:

| .NET SDK | ICU version | Download                                                                                                                 |
| -------- | ----------- | ------------------------------------------------------------------------------------------------------------------------ |
| .NET 8   | 68          | [icu4c-68.2-data-bin-l.zip](https://github.com/unicode-org/icu/releases/download/release-68-2/icu4c-68.2-data-bin-l.zip) |
| .NET 9   | 68          | [icu4c-68.2-data-bin-l.zip](https://github.com/unicode-org/icu/releases/download/release-68-2/icu4c-68.2-data-bin-l.zip) |
| .NET 10  | 72          | [icu4c-72_1-data-bin-l.zip](https://github.com/unicode-org/icu/releases/download/release-72-1/icu4c-72_1-data-bin-l.zip) |

Extract the .dat file from the archive and include it in your project.

```xml
<PropertyGroup>
    <WasmNativeStrip>false</WasmNativeStrip>
    <BlazorIcuDataFileName>native/icudt_custom.dat</BlazorIcuDataFileName>
</PropertyGroup>
```

>[!Note]
>The file name must start with icudt (for example, icudt_custom.dat) because this is required by the WASM toolchain.

File to review: [icudt_custom.dat](BlazorWasmCustomIcuInteropExample/BlazorWasmCustomIcuInteropExample.Client/Native/icudt_custom.dat)

### Implement a Custom ICU Interop Class

DevExpress supplies an `ICustomICUInterop` interface that allows you to route ICU calls to your native implementation.

Your C# wrapper should use `DllImport` to reference functions exposed by the native `wrapper.c` file as illustrated in the following example:

```cs
public class CustomInterop : ICustomICUInterop {
    [DllImport("wrapper")]
    static extern int ubidi_countRuns_wrapper(IntPtr pBiDi, out UErrorCode errorCode);
    ...
    public int UBiDiCountRuns(IntPtr pBiDi, out UErrorCode errorCode) {
        return ubidi_countRuns_wrapper(pBiDi, out errorCode);
    }
    ...
}
```

File to review: [IcuInterop.cs](BlazorWasmCustomIcuInteropExample/BlazorWasmCustomIcuInteropExample.Client/Native/IcuInterop.cs)

>[!Important]
>The library name in DllImport must match the wrapper file name without extension.

If native function names differ, specify the entry point:

[DllImport("wrapper", EntryPoint = "my_custom_function")]

### Register the Custom Interop Provider

Assign your custom interop implementation during application initialization:

```cs
ICUInterop.CustomIcuInterop = new CustomInterop();
```

File to review: [Program.cs](BlazorWasmCustomIcuInteropExample/BlazorWasmCustomIcuInteropExample.Client/Program.cs)

Once this is complete, DevExpress components will route all ICU dependent operations through your implementation and use the full ICU data you supplied.

## Files to Review

* [wrapper.c](BlazorWasmCustomIcuInteropExample/BlazorWasmCustomIcuInteropExample.Client/Native/wrapper.c)
* [icudt_custom.dat](BlazorWasmCustomIcuInteropExample/BlazorWasmCustomIcuInteropExample.Client/Native/icudt_custom.dat)
* [IcuInterop.cs](BlazorWasmCustomIcuInteropExample/BlazorWasmCustomIcuInteropExample.Client/Native/IcuInterop.cs)
* [Program.cs](BlazorWasmCustomIcuInteropExample/BlazorWasmCustomIcuInteropExample.Client/Program.cs) 

<!-- feedback -->
## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=example-repository-template&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=example-repository-template&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
